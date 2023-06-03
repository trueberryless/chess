using Chess.Application.DTO;
using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.Enums;
using Chess.Domain.ValueObjects;
using Mapster;

namespace Chess.Application.Services.Implementations;

public class BoardService : IBoardService
{
    private readonly IRepository<Board> _boardRepository;

    public BoardService(IRepository<Board> boardRepository)
    {
        _boardRepository = boardRepository;
    }
    
    public IEnumerable<BoardDto> GetBoards() =>
        _boardRepository.Read().Select(b => b.Adapt<BoardDto>());

    public BoardDto GetBoard(int id)=>
        _boardRepository.Read(id).Adapt<BoardDto>();

    public BoardDto CreateBoard()
    {
        var newBoard = new Board();
        newBoard.CreatedOn = DateTime.Now;

        newBoard = SetStartPosition(newBoard);

        return newBoard.Adapt<BoardDto>();
    }

    public void DeleteBoard(int id) =>
        _boardRepository.Delete(id);

    public BoardDto ResetBoard(int id) =>
        SetStartPosition(_boardRepository.Read(id)).Adapt<BoardDto>();

    public IEnumerable<PieceDto> GetPieces(int id) =>
        _boardRepository.Read(id).Pieces.Select(p => p.Adapt<PieceDto>());

    private static Board SetStartPosition(Board board)
    {
        board.Pieces = new List<Piece>();
        board.Ply = 0;
        
        for (int y = 0; y < 8; y++)
        {
            if (new List<int>() { 2, 3, 4, 5 }.Contains(y))
                continue;
            
            for (int x = 0; x < 8; x++)
            {
                var newPiece = new Piece();
                newPiece.Color = y <= 3 ? PieceColor.WHITE : PieceColor.BLACK;
                newPiece.Position = new Field(x, y);

                if (new List<int>() { 1, 6 }.Contains(y))
                    newPiece.Type = PieceType.PAWN;
                
                else if (new List<int>() { 0, 7 }.Contains(x))
                    newPiece.Type = PieceType.ROOK;
                
                else if (new List<int>() { 1, 6 }.Contains(x))
                    newPiece.Type = PieceType.KNIGHT;
                
                else if (new List<int>() { 2, 5 }.Contains(x))
                    newPiece.Type = PieceType.BISHOP;
                
                else if (x == 3)
                    newPiece.Type = PieceType.QUEEN;
                
                else if (x == 4)
                    newPiece.Type = PieceType.KING;
                
                board.Pieces.Add(newPiece);
            }
        }

        return board;
    }
}