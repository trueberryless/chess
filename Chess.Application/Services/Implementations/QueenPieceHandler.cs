using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Implementations;

public class QueenPieceHandler : IPieceHandler
{
    public bool CanMove(Board board, Piece piece, Field targetField)
    {
        throw new NotImplementedException();
    }

    public bool IsOccupiedByPiece(Board board, Piece piece, Field targetField)
    {
        throw new NotImplementedException();
    }

    public bool IsBasicMovementAllowed(Piece piece, Field targetField)
    {
        throw new NotImplementedException();
    }
}