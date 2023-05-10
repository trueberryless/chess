using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;

namespace Chess.Application.DTO;

public record PieceDto
{
    public int Id { get; set; }

    public EPieceColor Color { get; set; }

    public EPieceType Type { get; set; }

    public Field? Position { get; set; }
}