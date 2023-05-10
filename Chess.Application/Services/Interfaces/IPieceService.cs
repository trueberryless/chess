using Chess.Application.DTO;

namespace Chess.Application.Services.Interfaces;

public interface IPieceService
{
    PieceDto Move(int id);
}