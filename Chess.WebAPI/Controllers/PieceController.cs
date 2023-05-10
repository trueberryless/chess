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
        throw new NotImplementedException();
    }
}