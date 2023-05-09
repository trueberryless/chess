using System.Text.Json.Nodes;
using Chess.Application.DTO;
using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Controllers;

[ApiController]
[Route("api/board")]
public class BoardController : Controller
{
    private readonly IBoardService _boardService;

    public BoardController(IBoardService boardService)
    {
        _boardService = boardService;
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<BoardDto>> GetBoards()
    {
        return Ok(_boardService.GetBoards());
        // Statuscodes: 200 JsonArray: Boards
    }

    [HttpGet("{id:int}")]
    public ActionResult<BoardDto> GetBoard(int id)
    {
        throw new NotImplementedException();
        // Statuscodes: 200 JsonObject: Board, 400 Invalid Id
    }

    [HttpPost]
    public ActionResult<BoardDto> CreateBoard()
    {
        throw new NotImplementedException();
        // Statuscodes: 200 JsonObject: Board
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteBoard(int id)
    {
        throw new NotImplementedException();
        // Statuscode: 200, 400 Invalid Id
    }

    [HttpPut("{id:int}")]
    public ActionResult ResetBoard(int id)
    {
        throw new NotImplementedException();
        // Statuscodes: 200 JsonObject: Board, 400 Invalid Id
    }
    
    [HttpGet("{id:int}/pieces")]
    public ActionResult<IEnumerable<PieceDto>> GetPieces(int id)
    {
        throw new NotImplementedException();
        // Statuscodes: 200 JsonArray: Pieces, 400 Invalid Id
    }
}