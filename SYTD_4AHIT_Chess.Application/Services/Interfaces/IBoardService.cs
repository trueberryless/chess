using SYTD_4AHIT_Chess.Application.DataTransfer;

namespace SYTD_4AHIT_Chess.Application.Services.Interfaces
{
    public interface IBoardService
    {
        IEnumerable<BoardDto> GetBoards();
    }
}