using Chess.Application.DTO;
using Chess.Application.Services.Interfaces;

namespace Chess.Application.Services.Implementations;

public class BoardService : IBoardService
{
    public IEnumerable<BoardDto> GetBoards()
    {
        throw new NotImplementedException();
    }

    public BoardDto GetBoard(int id)
    {
        throw new NotImplementedException();
    }

    public BoardDto CreateBoard()
    {
        throw new NotImplementedException();
    }

    public void DeleteBoard(int id)
    {
        throw new NotImplementedException();
    }

    public BoardDto ResetBoard(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PieceDto> GetPieces(int id)
    {
        throw new NotImplementedException();
    }
}