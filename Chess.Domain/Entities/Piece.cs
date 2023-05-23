using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;

namespace Chess.Domain.Entities;

public class Piece
{
    public int Id { get; set; }
    
    public int BoardId { get; set; }
    
    public Board Board { get; set; }

    public PieceColor Color { get; set; }

    public PieceType Type { get; set; }

    public Field? Position { get; set; }
}