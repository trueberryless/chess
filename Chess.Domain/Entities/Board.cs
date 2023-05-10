﻿namespace Chess.Domain.Entities;

public class Board
{
    public int Id { get; set; }
    
    public List<Piece> Pieces { get; set; }
}