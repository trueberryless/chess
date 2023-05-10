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
        try
        {
            return Ok(_boardService.GetBoards());
        }
        catch (NotImplementedException e)
        {
            return StatusCode(501, "NotImplementedException");
        }
    }

    [HttpGet("{id:int}")]
    public ActionResult<BoardDto> GetBoard(int id)
    {
        try
        {
            return Ok(_boardService.GetBoard(id));
        }
        catch (KeyNotFoundException)
        {
            return BadRequest();
        }
        catch (NotImplementedException)
        {
            return StatusCode(501, "NotImplementedException");
        }
    }

    [HttpPost]
    public ActionResult<BoardDto> CreateBoard()
    {
        try
        {
            return Ok(_boardService.CreateBoard());
        }
        catch (NotImplementedException e)
        {
            return StatusCode(501, "NotImplementedException");
        }
    }

    [HttpDelete("{id:int}")]
    public ActionResult DeleteBoard(int id)
    {
        try
        {
            _boardService.DeleteBoard(id);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return BadRequest();
        }
        catch (NotImplementedException)
        {
            return StatusCode(501, "NotImplementedException");
        }
    }

    [HttpPut("{id:int}")]
    public ActionResult ResetBoard(int id)
    {
        try
        {
            _boardService.ResetBoard(id);
            return Ok();
        }
        catch (KeyNotFoundException)
        {
            return BadRequest();
        }
        catch (NotImplementedException)
        {
            return StatusCode(501, "NotImplementedException");
        }
    }
    
    [HttpGet("{id:int}/pieces")]
    public ActionResult<IEnumerable<PieceDto>> GetPieces(int id)
    {
        try
        {
            return Ok(_boardService.GetPieces(id));
        }
        catch (KeyNotFoundException)
        {
            return BadRequest();
        }
        catch (NotImplementedException)
        {
            return StatusCode(501, "NotImplementedException");
        }
    }
}