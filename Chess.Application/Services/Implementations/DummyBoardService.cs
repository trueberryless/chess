using Chess.Application.DTO;
using Chess.Application.Services.Interfaces;

namespace Chess.Application.Services.Implementations;

public class DummyBoardService : IBoardService
{
    public async IAsyncEnumerable<BoardDto> GetBoards()
    {
        for (int i = 1; i < 5; i++)
        {
            yield return new BoardDto()
            {
                Id = i, 
                CreatedOn = DateTime.Now.AddDays(-i * 4),
            };
        }
    }
}