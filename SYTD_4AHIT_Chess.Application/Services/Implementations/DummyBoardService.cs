using SYTD_4AHIT_Chess.Application.DataTransfer;
using SYTD_4AHIT_Chess.Application.Services.Interfaces;

namespace SYTD_4AHIT_Chess.Application.Services.Implementations
{
    public class DummyBoardService : IBoardService
    {
        public IEnumerable<BoardDto> GetBoards()
        {
            int count = 3;

            for (int i = 0; i < count; i++)
            {
                yield return new BoardDto
                {
                    Id = i + 1,
                    CreatedOn = DateTime.Now.AddDays(-count - i)
                };
            }
        }
    }
}