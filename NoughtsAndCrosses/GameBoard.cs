namespace NoughtsAndCrosses
{
    using System;

    public class GameBoard : IGameBoard
    {
        private const char Empty = ' ';

        readonly char[,] squares = new char[3,3];

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

        public bool IsFree(Position position)
        {
            return squares[position.X, position.Y] == Empty;
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

        public bool GameIsOver()
        {
            return false;
            throw new NotImplementedException();
        }
    }
}