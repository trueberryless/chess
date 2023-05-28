using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Implementations;

public class KingPieceHandler : IPieceHandler
{
    private readonly CompositePieceHandler _compositePieceHandler;

    public KingPieceHandler(CompositePieceHandler compositePieceHandler)
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
        #region Check if movement of piece is valid

        if (targetField.X is > 7 or < 0 || targetField.Y is > 7 or < 0)
            return false;

        if (piece.Position == null)
            return false;

        if (!OneSquareAway(piece.Position, targetField))
            return false;

        #endregion

        #region Check if opponent king is not near own king
        
        var opponentPieceColor = piece.Color == PieceColor.WHITE ? PieceColor.BLACK : PieceColor.WHITE;

        var opponentKingPosition = board.Pieces
            .FirstOrDefault(p => p.Color == opponentPieceColor && p.Type == PieceType.KING)
            ?.Position;
        
        if (opponentKingPosition == null)
            return false;

        if (OneSquareAway(opponentKingPosition, targetField))
            return false;

        #endregion

        #region Check if targetField is not occupied by own piece

        if (board.Pieces.All(otherPiece => otherPiece.Position == targetField && otherPiece.Color == piece.Color))
            return false;

        #endregion

        return false;
    }

    private bool OneSquareAway(Field p1, Field p2)
    {
        return (p1.X + 0 == p2.X && p1.Y + 1 == p2.Y) ||
               (p1.X + 1 == p2.X && p1.Y + 1 == p2.Y) ||
               (p1.X + 1 == p2.X && p1.Y - 0 == p2.Y) ||
               (p1.X + 1 == p2.X && p1.Y - 1 == p2.Y) ||
               (p1.X - 0 == p2.X && p1.Y - 1 == p2.Y) ||
               (p1.X - 1 == p2.X && p1.Y - 1 == p2.Y) ||
               (p1.X - 1 == p2.X && p1.Y + 0 == p2.Y) ||
               (p1.X - 1 == p2.X && p1.Y + 1 == p2.Y);
    }
}