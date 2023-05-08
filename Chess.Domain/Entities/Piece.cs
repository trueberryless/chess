using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;

namespace Chess.Domain.Entities;

public class Piece
{
    public int Id { get; set; }

    public EPieceColor Color { get; set; }

    public EPieceType Type { get; set; }

    public Field? Position { get; set; }
}