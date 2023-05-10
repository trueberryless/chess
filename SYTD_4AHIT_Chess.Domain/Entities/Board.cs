namespace SYTD_4AHIT_Chess.Domain.Entities
{
    public class Board
    {
        public int Id { get; set; }

        public List<Piece> Pieces { get; set; }
    }
}