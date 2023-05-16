namespace Chess.Domain.Entities;

public class Board
{
    public int Id { get; set; }
    
    public List<Piece> Pieces { get; set; }
    
    public DateTime CreatedOn { get; set; }
    
    public int Ply { get; set; }
}