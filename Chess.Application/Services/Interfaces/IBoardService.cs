using Chess.Application.DTO;

namespace Chess.Application.Services.Interfaces;

public interface IBoardService
{
    IEnumerable<BoardDto> GetBoards();

    BoardDto GetBoard(int id);

    BoardDto CreateBoard();

    void DeleteBoard(int id);

    BoardDto ResetBoard(int id);

    IEnumerable<PieceDto> GetPieces(int id);
}