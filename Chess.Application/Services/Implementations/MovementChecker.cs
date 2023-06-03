using Chess.Application.Services.Interfaces;
using Chess.Domain.Entities;
using Chess.Domain.ValueObjects;

namespace Chess.Application.Services.Implementations;

public class MovementChecker : IMovable
{
    public bool CanMoveOrthogonal(Board board, Piece piece, Field targetField)
    {
        #region Check if movement of piece is valid and if fields are not occupied by pieces
        
        if (targetField.X is > 7 or < 0 || targetField.Y is > 7 or < 0)
            return false;

        if (piece.Position == null)
            return false;

        if (!(piece.Position.X == targetField.X || piece.Position.Y == targetField.Y))
            return false;
        
        if (board.Pieces.Any(otherPiece => otherPiece.Position == targetField && otherPiece.Color == piece.Color))
            return false;
        
        if (piece.Position.X == targetField.X && piece.Position.Y < targetField.Y)
            for (var i = piece.Position.Y + 1; i <= targetField.Y - 1; i++)
                if (board.Pieces.Any(otherPiece =>
                        otherPiece.Position != null && 
                        otherPiece.Position.X == piece.Position.X &&
                        otherPiece.Position.Y == i))
                    return false;
        
        if (piece.Position.X == targetField.X && piece.Position.Y > targetField.Y)
            for (var i = piece.Position.Y - 1; i >= targetField.Y + 1; i--)
                if (board.Pieces.Any(otherPiece =>
                        otherPiece.Position != null && 
                        otherPiece.Position.X == piece.Position.X &&
                        otherPiece.Position.Y == i))
                    return false;
        
        if (piece.Position.X < targetField.X && piece.Position.Y == targetField.Y)
            for (var i = piece.Position.X + 1; i >= targetField.X - 1; i++)
                if (board.Pieces.Any(otherPiece =>
                        otherPiece.Position != null && 
                        otherPiece.Position.X == piece.Position.X &&
                        otherPiece.Position.Y == i))
                    return false;
        
        if (piece.Position.X > targetField.X && piece.Position.Y == targetField.Y)
            for (var i = piece.Position.X - 1; i >= targetField.X + 1; i--)
                if (board.Pieces.Any(otherPiece =>
                        otherPiece.Position != null && 
                        otherPiece.Position.X == piece.Position.X &&
                        otherPiece.Position.Y == i))
                    return false;
        
        #endregion

        return true;
    }
    
    public bool CanMoveDiagonal(Board board, Piece piece, Field targetField)
    {
        #region Check if movement of piece is valid and if fields are not occupied by pieces
        
        if (targetField.X is > 7 or < 0 || targetField.Y is > 7 or < 0)
            return false;

        if (piece.Position == null)
            return false;

        if (piece.Position == targetField)
            return false;

        if (Math.Abs(piece.Position.X - targetField.X) != Math.Abs(piece.Position.Y - targetField.Y))
            return false;
        
        if (board.Pieces.Any(otherPiece => otherPiece.Position == targetField && otherPiece.Color == piece.Color))
            return false;
        
        if (piece.Position.X < targetField.X && piece.Position.Y < targetField.Y)
            for (var currentPosition = new Field(piece.Position.X + 1, piece.Position.Y + 1);
                 currentPosition.X < targetField.X && currentPosition.Y < targetField.Y;
                 currentPosition.X++, currentPosition.Y++)
                if (board.Pieces.Any(otherPiece =>
                        otherPiece.Position != null &&
                        otherPiece.Position.X == currentPosition.X &&
                        otherPiece.Position.Y == currentPosition.Y))
                    return false;
        
        if (piece.Position.X > targetField.X && piece.Position.Y < targetField.Y)
            for (var currentPosition = new Field(piece.Position.X + 1, piece.Position.Y + 1);
                 currentPosition.X > targetField.X && currentPosition.Y < targetField.Y;
                 currentPosition.X++, currentPosition.Y++)
                if (board.Pieces.Any(otherPiece =>
                        otherPiece.Position != null &&
                        otherPiece.Position.X == currentPosition.X &&
                        otherPiece.Position.Y == currentPosition.Y))
                    return false;
        
        if (piece.Position.X < targetField.X && piece.Position.Y > targetField.Y)
            for (var currentPosition = new Field(piece.Position.X + 1, piece.Position.Y + 1);
                 currentPosition.X < targetField.X && currentPosition.Y > targetField.Y;
                 currentPosition.X++, currentPosition.Y++)
                if (board.Pieces.Any(otherPiece =>
                        otherPiece.Position != null &&
                        otherPiece.Position.X == currentPosition.X &&
                        otherPiece.Position.Y == currentPosition.Y))
                    return false;
        
        if (piece.Position.X > targetField.X && piece.Position.Y > targetField.Y)
            for (var currentPosition = new Field(piece.Position.X + 1, piece.Position.Y + 1);
                 currentPosition.X > targetField.X && currentPosition.Y > targetField.Y;
                 currentPosition.X++, currentPosition.Y++)
                if (board.Pieces.Any(otherPiece =>
                        otherPiece.Position != null &&
                        otherPiece.Position.X == currentPosition.X &&
                        otherPiece.Position.Y == currentPosition.Y))
                    return false;

        #endregion

        return true;
    }

    public bool CanMoveAngular(Board board, Piece piece, Field targetField)
    {
        #region Check if movement of piece is valid and if targetField is not occupied by own piece

        if (targetField.X is > 7 or < 0 || targetField.Y is > 7 or < 0)
            return false;

        if (piece.Position == null)
            return false;

        if (!((piece.Position.X + 1 == targetField.X && piece.Position.Y + 2 == targetField.Y) ||
              (piece.Position.X + 2 == targetField.X && piece.Position.Y + 1 == targetField.Y) ||
              (piece.Position.X + 2 == targetField.X && piece.Position.Y - 1 == targetField.Y) ||
              (piece.Position.X + 1 == targetField.X && piece.Position.Y - 2 == targetField.Y) ||
              (piece.Position.X - 1 == targetField.X && piece.Position.Y - 2 == targetField.Y) ||
              (piece.Position.X - 2 == targetField.X && piece.Position.Y - 1 == targetField.Y) ||
              (piece.Position.X - 2 == targetField.X && piece.Position.Y + 1 == targetField.Y) ||
              (piece.Position.X - 1 == targetField.X && piece.Position.Y + 2 == targetField.Y)))
            return false;
        
        if (board.Pieces.Any(otherPiece => otherPiece.Position == targetField && otherPiece.Color == piece.Color))
            return false;

        #endregion

        return true;
    }

    public bool CanMoveOneSquare(Board board, Piece piece, Field targetField)
    {
        #region Check if movement of piece is valid and if targetField is not occupied by own piece

        if (targetField.X is > 7 or < 0 || targetField.Y is > 7 or < 0)
            return false;

        if (piece.Position == null)
            return false;

        if (!((piece.Position.X + 0 == targetField.X && piece.Position.Y + 1 == targetField.Y) ||
              (piece.Position.X + 1 == targetField.X && piece.Position.Y + 1 == targetField.Y) ||
              (piece.Position.X + 1 == targetField.X && piece.Position.Y - 0 == targetField.Y) ||
              (piece.Position.X + 1 == targetField.X && piece.Position.Y - 1 == targetField.Y) ||
              (piece.Position.X - 0 == targetField.X && piece.Position.Y - 1 == targetField.Y) ||
              (piece.Position.X - 1 == targetField.X && piece.Position.Y - 1 == targetField.Y) ||
              (piece.Position.X - 1 == targetField.X && piece.Position.Y + 0 == targetField.Y) ||
              (piece.Position.X - 1 == targetField.X && piece.Position.Y + 1 == targetField.Y)))
            return false;

        if (board.Pieces.Any(otherPiece => otherPiece.Position == targetField && otherPiece.Color == piece.Color))
            return false;

        #endregion
        
        return true;
    }
}