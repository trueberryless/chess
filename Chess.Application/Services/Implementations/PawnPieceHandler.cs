using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Implementations;

public class PawnPieceHandler : IPieceHandler
{
    public bool CanMove(Board board, Piece piece, Field targetField)
    {
        // Basic Movement Restrictions
        if (piece.Position == null)
            return false;

        if (!IsBasicMovementAllowed(piece, targetField))
            return false;

        return true;
    }

    public bool IsOccupiedByPiece(Board board, Piece piece, Field targetField)
    {
        throw new NotImplementedException();
    }

    public bool IsBasicMovementAllowed(Piece piece, Field targetField)
    {
        if (piece.Color == PieceColor.WHITE)
        {
            if (piece.Position.Y + 1 == targetField.Y
                && piece.Position.X == targetField.X)
            {
                
            }
        }

        return true;
    }
}