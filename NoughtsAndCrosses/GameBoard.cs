using System;

namespace NoughtsAndCrosses
{
    public class GameBoard : IGameBoard
    {
        private const char Empty = ' ';

        readonly char[,] squares = new char[3,3];

        private char winner;

        public GameBoard()
        {
            Set(squares, Empty);
        }

        private void Set(char[,] squares, char player)
        {
            for (var y = 0; y < squares.GetLength(0); y++)
                for (var x = 0; x < squares.GetLength(1); x++)
                    squares[y, x] = player;
        }

        public void Move(Player player, Position position)
        {
            squares[position.X, position.Y] = player.Sign;
        }

        public string Display()
        {
            var result = string.Empty;
            for (var y = 0; y < squares.GetLength(0); y++)
            {
                for (var x = 0; x < squares.GetLength(1); x++)
                {
                    result += "[" + squares[x, y] + "]";
                }

                result += Environment.NewLine;
            }
            return result;
        }

        public bool IsFree(Position position)
        {
            return squares[position.X, position.Y] == Empty;
        }

        public string Result
        {
            get
            {
                if (FullBoard())
                    return "Draw!";

                return string.Format("{0} Wins!", winner);
            }
        }

        public bool GameIsOver()
        {
            return ThreeEqualInARow() || ThreeEqualInAColumn() || ThreeEqualInDiagonal() || FullBoard();
        }

        private bool FullBoard()
        {
            foreach (var square in squares)
            {
                if(square == Empty)
                    return false;
            }

            return true;
        }

        private bool ThreeEqualInARow()
        {
            for (var y = 0; y < squares.GetLength(0); y++)
            {
                if (!IsFree(new Position(0, y)) &&
                    squares[0, y] == squares[1, y] && squares[0, y] == squares[2, y])
                {
                    winner = squares[0, y];
                    return true;
                }
                    
            }
            return false;
        }

        private bool ThreeEqualInAColumn()
        {
            for (var x = 0; x < squares.GetLength(0); x++)
            {
                if (!IsFree(new Position(x, 0)) &&
                    squares[x, 0] == squares[x, 1] && squares[x, 0] == squares[x, 2])
                {
                    winner = squares[x, 0];
                    return true;
                }
            }
            return false;
        }

        private bool ThreeEqualInDiagonal()
        {
            if (!IsFree(new Position(1, 1)) &&
                (squares[1, 1] == squares[0, 0] && squares[1, 1] == squares[2, 2] || 
                 squares[1, 1] == squares[2, 0] && squares[1, 1] == squares[0, 2]))
            {
                winner = squares[1, 1];
                return true;
            }
            return false;
        }
    }
}