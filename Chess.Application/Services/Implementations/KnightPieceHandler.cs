using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Implementations;

public class KnightPieceHandler : IPieceHandler
{
    public bool CanMove(Board board, Piece piece, Field targetField)
    {
        // Basic Movement Restrictions
        if (piece.Position == null)
            return false;

        return IsBasicMovementAllowed(piece, targetField) && IsOccupiedByPiece(board, piece, targetField);
    }

    public bool IsOccupiedByPiece(Board board, Piece piece, Field targetField)
    {
        return board.Pieces.All(otherPiece => otherPiece.Position != targetField || otherPiece.Color != piece.Color);
    }

    public bool IsBasicMovementAllowed(Piece piece, Field targetField)
    {
        return (piece.Position.X + 1 == targetField.X && piece.Position.Y + 2 == targetField.Y) ||
               (piece.Position.X + 2 == targetField.X && piece.Position.Y + 1 == targetField.Y) ||
               (piece.Position.X + 2 == targetField.X && piece.Position.Y - 1 == targetField.Y) ||
               (piece.Position.X + 1 == targetField.X && piece.Position.Y - 2 == targetField.Y) ||
               (piece.Position.X - 1 == targetField.X && piece.Position.Y - 2 == targetField.Y) ||
               (piece.Position.X - 2 == targetField.X && piece.Position.Y - 1 == targetField.Y) ||
               (piece.Position.X - 2 == targetField.X && piece.Position.Y + 1 == targetField.Y) ||
               (piece.Position.X - 1 == targetField.X && piece.Position.Y + 2 == targetField.Y);
    }
}