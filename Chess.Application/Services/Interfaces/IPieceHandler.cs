using Chess.Domain.Entities;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Interfaces;

public interface IPieceHandler
{
    bool CanMove(Board board, Piece piece, Field targetField);

    bool IsOccupiedByPiece(Board board, Piece piece, Field targetField);

    bool IsBasicMovementAllowed(Piece piece, Field targetField);
    
}