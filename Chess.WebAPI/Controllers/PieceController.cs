using Chess.Application.DTO;
using Chess.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Chess.Controllers;

[ApiController]
[Route("api/piece")]
public class PieceController : Controller
{
    private readonly IPieceService _pieceService;

    public PieceController(IPieceService pieceService)
    {
        _pieceService = pieceService;
    }

    [HttpPut("move/{id:int}/{x:int}/{y:int}")]
    public ActionResult<PieceDto> Move(int id, int x, int y)
    {
        try
        {
            return Ok(_pieceService.Move(new MovementDto(id, x, y)));
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
    
    [HttpGet("move/{id:int}/{x:int}/{y:int}")]
    public ActionResult<bool> CanMove(int id, int x, int y)
    {
        try
        {
            return Ok(_pieceService.CanMove(new MovementDto(id, x, y)));
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