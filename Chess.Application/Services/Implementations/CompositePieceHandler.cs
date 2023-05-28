using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;
using Microsoft.Extensions.DependencyInjection;

namespace Chess.Application.Services.Implementations;

public class CompositePieceHandler : IPieceHandler
{
    private readonly BishopPieceHandler _bishopPieceHandler;
    private readonly KingPieceHandler _kingPieceHandler;
    private readonly KnightPieceHandler _knightPieceHandler;
    private readonly PawnPieceHandler _pawnPieceHandler;
    private readonly QueenPieceHandler _queenPieceHandler;
    private readonly RookPieceHandler _rookPieceHandler;

    public CompositePieceHandler(IServiceProvider serviceProvider)
    {
        _bishopPieceHandler = serviceProvider.GetRequiredService<BishopPieceHandler>();
        _kingPieceHandler = serviceProvider.GetRequiredService<KingPieceHandler>();
        _knightPieceHandler = serviceProvider.GetRequiredService<KnightPieceHandler>();
        _pawnPieceHandler = serviceProvider.GetRequiredService<PawnPieceHandler>();
        _queenPieceHandler = serviceProvider.GetRequiredService<QueenPieceHandler>();
        _rookPieceHandler = serviceProvider.GetRequiredService<RookPieceHandler>();
    }

    public bool CanMove(Board board, Piece piece, Field targetField) =>
        piece.Type switch
        {
            PieceType.BISHOP => _bishopPieceHandler.CanMove(board, piece, targetField),
            PieceType.KING => _kingPieceHandler.CanMove(board, piece, targetField),
            PieceType.KNIGHT => _knightPieceHandler.CanMove(board, piece, targetField),
            PieceType.PAWN => _pawnPieceHandler.CanMove(board, piece, targetField),
            PieceType.QUEEN => _queenPieceHandler.CanMove(board, piece, targetField),
            PieceType.ROOK => _rookPieceHandler.CanMove(board, piece, targetField),
            _ => throw new ArgumentOutOfRangeException()
        };

    public bool IsBasicMovementAllowed(Board board, Piece piece, Field targetField) =>
        piece.Type switch
        {
            PieceType.BISHOP => _bishopPieceHandler.IsBasicMovementAllowed(board, piece, targetField),
            PieceType.KING => _kingPieceHandler.IsBasicMovementAllowed(board, piece, targetField),
            PieceType.KNIGHT => _knightPieceHandler.IsBasicMovementAllowed(board, piece, targetField),
            PieceType.PAWN => _pawnPieceHandler.IsBasicMovementAllowed(board, piece, targetField),
            PieceType.QUEEN => _queenPieceHandler.IsBasicMovementAllowed(board, piece, targetField),
            PieceType.ROOK => _rookPieceHandler.IsBasicMovementAllowed(board, piece, targetField),
            _ => throw new ArgumentOutOfRangeException()
        };
}