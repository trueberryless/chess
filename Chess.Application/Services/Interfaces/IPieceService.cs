using Chess.Application.DTO;

namespace Chess.Application.Services.Interfaces;

public interface IPieceService
{
    PieceDto Move(MovementDto movementDto);
    
    bool CanMove(MovementDto movementDto);
}