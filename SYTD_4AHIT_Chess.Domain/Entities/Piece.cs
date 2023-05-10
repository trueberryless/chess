using SYTD_4AHIT_Chess.Domain.Enums;
using SYTD_4AHIT_Chess.Domain.ValueObjects;

namespace SYTD_4AHIT_Chess.Domain.Entities
{
    public class Piece
    {
        public int Id { get; set; }

        public bool IsBlack { get; set; }
        public PieceType Type { get; set; }

        public FieldPosition FieldPosition { get; set; }
    }
}