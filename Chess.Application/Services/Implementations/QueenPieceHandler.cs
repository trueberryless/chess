using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Implementations;

public class QueenPieceHandler : IPieceHandler
{
    private readonly CompositePieceHandler _compositePieceHandler;
    private readonly IMovable _movement;

    public QueenPieceHandler(CompositePieceHandler compositePieceHandler, IMovable movement)
    {
        _compositePieceHandler = compositePieceHandler;
        _movement = movement;
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

    public bool IsBasicMovementAllowed(Board board, Piece piece, Field targetField) =>
        _movement.CanMoveOrthogonal(board, piece, targetField) || _movement.CanMoveDiagonal(board, piece, targetField);
}