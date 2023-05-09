using Chess.Application.DTO;

namespace Chess.Application.Services.Interfaces;

public interface IBoardService
{
    IAsyncEnumerable<BoardDto> GetBoards();
}