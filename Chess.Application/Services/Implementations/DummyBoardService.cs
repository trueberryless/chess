﻿using Chess.Application.DTO;
using Chess.Application.Services.Interfaces;

namespace Chess.Application.Services.Implementations;

public class DummyBoardService : IBoardService
{
    public IEnumerable<BoardDto> GetBoards()
    {
        for (int i = 1; i < 5; i++)
        {
            yield return new BoardDto()
            {
                Id = i, 
                CreatedOn = DateTime.Now.AddDays(-i * 4),
            };
        }
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

    public void ResetBoard(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<PieceDto> GetPieces(int id)
    {
        throw new NotImplementedException();
    }
}