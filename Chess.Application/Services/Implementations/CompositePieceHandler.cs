using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Implementations;

public class CompositePieceHandler : IPieceHandler
{
    private readonly PawnPieceHandler _pawnPieceHandler;

    public CompositePieceHandler(PawnPieceHandler pawnPieceHandler)
    {
        _pawnPieceHandler = pawnPieceHandler;
    }
    
    public bool CanMove(Board board, Piece piece, Field targetField)
    {
        // TODO make switch
        if (piece.Type == PieceType.PAWN)
            return _pawnPieceHandler.CanMove(board, piece, targetField);
        throw new NotImplementedException();
    }
}