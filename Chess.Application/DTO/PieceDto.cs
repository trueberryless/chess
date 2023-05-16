using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;

namespace Chess.Application.DTO;

public record PieceDto
{
    public int Id { get; set; }

    public PieceColor Color { get; set; }

    public PieceType Type { get; set; }

    public Field? Position { get; set; }
}