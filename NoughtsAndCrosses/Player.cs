namespace NoughtsAndCrosses
{
    using System;

    public class Player
    {
        private static readonly Random random = new Random();

        public Player(char sign)
        {
            Sign = sign;
        }

        public char Sign { get; private set; }

        public Position NextMove(IGameBoard gameBoard)
        {
            if(gameBoard.GameIsOver())
                return new NoPosition();

            var point = RandomPosition();
            if(gameBoard.IsFree(point))
                return point;

            return NextMove(gameBoard);
        }

        private static Position RandomPosition()
        {
            return new Position(random.Next(0, 3), random.Next(0, 3));
        }
    }
}