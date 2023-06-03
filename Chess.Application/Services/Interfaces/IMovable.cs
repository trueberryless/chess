using Chess.Domain.Entities;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Interfaces;

public interface IMovable
{
    bool CanMoveOrthogonal(Board board, Piece piece, Field targetField);
    bool CanMoveDiagonal(Board board, Piece piece, Field targetField);
    bool CanMoveAngular(Board board, Piece piece, Field targetField);
    bool CanMoveOneSquare(Board board, Piece piece, Field targetField);
}