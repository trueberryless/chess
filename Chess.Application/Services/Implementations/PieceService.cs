using Microsoft.Extensions.DependencyInjection;
using Chess.Application.DTO;
using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Implementations;

public class PieceService : IPieceService
{
    private readonly IPieceHandler _pieceHandler;
    private readonly IRepository<Piece> _pieceRepository;
    private readonly IRepository<Board> _boardRepository;

    public PieceService(IServiceProvider serviceProvider)
    {
        _pieceHandler = serviceProvider.GetRequiredService<IPieceHandler>();
        _pieceRepository = serviceProvider.GetRequiredService<IRepository<Piece>>();
        _boardRepository = serviceProvider.GetRequiredService<IRepository<Board>>();
    }

    public PieceDto Move(MovementDto movementDto)
    {
        throw new NotImplementedException();
    }

    public bool CanMove(MovementDto movementDto)
    {
        var piece = _pieceRepository.Read(movementDto.PieceId);
        var board = _boardRepository.Read(piece.BoardId);
        var targetField = new Field(movementDto.X, movementDto.Y);
        
        return _pieceHandler.CanMove(board, piece, targetField);
    }
}