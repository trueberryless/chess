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

    [HttpPut("{id:int}")]
    public ActionResult<PieceDto> Move(int id)
    {
        try
        {
            return Ok(_pieceService.Move(id));
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