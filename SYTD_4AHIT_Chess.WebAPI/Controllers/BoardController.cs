using Microsoft.AspNetCore.Mvc;
using SYTD_4AHIT_Chess.Application.DataTransfer;
using SYTD_4AHIT_Chess.Application.Services.Interfaces;

namespace SYTD_4AHIT_Chess.WebAPI.Controllers
{
    [ApiController]
    [Route("Board")]
    public class BoardController : ControllerBase
    {
        private readonly IBoardService boardService;

        public BoardController(IBoardService boardService)
        {
            this.boardService = boardService;
        }

        [HttpGet]
        public IEnumerable<BoardDto> GetBoards()
        {
            return boardService.GetBoards();
        }
    }
}