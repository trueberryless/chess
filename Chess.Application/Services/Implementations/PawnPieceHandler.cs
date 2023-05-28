using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Implementations;

public class PawnPieceHandler : IPieceHandler
{
    private readonly CompositePieceHandler _compositePieceHandler;

    public PawnPieceHandler(CompositePieceHandler compositePieceHandler)
    {
        _compositePieceHandler = compositePieceHandler;
    }

    public bool CanMove(Board board, Piece piece, Field targetField)
    {
        #region Check for exceptions

        if (piece.Position == null)
            return false;

        if (board.Pieces.All(p => p.Id != piece.Id))
            return false;

        #endregion

        #region Check basic movement

        if (!IsBasicMovementAllowed(board, piece, targetField))
            return false;

        #endregion

        #region Check for check

        var currentPosition = piece.Position;

        // Move the piece in order to check for checks
        piece.Position = targetField;

        var ownPieceColor = piece.Color == PieceColor.WHITE ? PieceColor.WHITE : PieceColor.BLACK;
        var opponentPieceColor = piece.Color == PieceColor.WHITE ? PieceColor.BLACK : PieceColor.WHITE;

        var targetKing = board.Pieces
            .FirstOrDefault(p => p.Color == ownPieceColor && p.Type == PieceType.KING)
            ?.Position;

        if (board.Pieces.Where(p => p.Color == opponentPieceColor).Any(opponentPiece => targetKing != null &&
                _compositePieceHandler.IsBasicMovementAllowed(board, opponentPiece, targetKing)))
            return false;

        // Undo move to get current Board back
        piece.Position = currentPosition;

        #endregion

        return true;
    }

    public bool IsBasicMovementAllowed(Board board, Piece piece, Field targetField)
    {
        // En passant is not implemented because last move information cannot be accessed.

        #region Check if movement of piece is valid && Check if targetField is (not) occupied by (own) piece

        if (targetField.X is > 7 or < 0 || targetField.Y is > 7 or < 0)
            return false;

        if (piece.Position == null)
            return false;

        MoveForward moveForward = piece.Color == PieceColor.WHITE ? Add : Subtract;
        var startRank = piece.Color == PieceColor.WHITE ? 1 : 6;

        if (!((piece.Position.X + 0 == targetField.X && moveForward(piece.Position.Y, 1) == targetField.Y) ||
              (piece.Position.X + 0 == targetField.X && moveForward(piece.Position.Y, 2) == targetField.Y &&
               piece.Position.Y == startRank) ||
              (piece.Position.X + 1 == targetField.X && moveForward(piece.Position.Y, 1) == targetField.Y) ||
              (piece.Position.X - 1 == targetField.X && moveForward(piece.Position.Y, 1) == targetField.Y)))
            return false;

        if (piece.Position.X + 0 == targetField.X && moveForward(piece.Position.Y, 1) == targetField.Y)
            if (board.Pieces.Any(otherPiece => otherPiece.Position == targetField))
                return false;

        if (piece.Position.X + 0 == targetField.X && moveForward(piece.Position.Y, 2) == targetField.Y &&
            piece.Position.Y == startRank)
            if (board.Pieces.Any(otherPiece => otherPiece.Position == targetField) ||
                board.Pieces.Any(otherPiece => otherPiece.Position == new Field(piece.Position.X, moveForward(piece.Position.Y, 1))))
                return false;

        if ((piece.Position.X + 1 == targetField.X && moveForward(piece.Position.Y, 1) == targetField.Y) ||
            (piece.Position.X - 1 == targetField.X && moveForward(piece.Position.Y, 1) == targetField.Y))
            if (board.Pieces.All(otherPiece => otherPiece.Position != targetField) ||
                board.Pieces.Where(p => p.Color == PieceColor.WHITE)
                    .Any(otherPiece => otherPiece.Position == targetField))
                return false;

        #endregion

        return true;
    }

    private delegate int MoveForward(int currentYPosition, int moveBy);

    private int Add(int y, int by) => y + by;

    private int Subtract(int y, int by) => y - by;
}