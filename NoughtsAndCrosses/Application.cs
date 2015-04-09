namespace NoughtsAndCrosses
{
    using System;

    public class Application
    {
        private readonly IConsole console;

        private readonly IGameBoard gameBoard;

        public Application(IConsole console, IGameBoard gameBoard)
        {
            this.console = console;
            this.gameBoard = gameBoard;
        }

        public void Run()
        {
            console.WriteLine("Tic-Tac-Toe Game");
            console.WriteLine("================");

            console.WriteLine("Press Any Key to begin the game");
            console.ReadKey();

            var currentPlayer = 'X';
            do
            {
                console.WriteLine("Game Board:");
                console.WriteLine(gameBoard.Display());
                gameBoard.Move(currentPlayer, new Random().Next(0, 3), new Random().Next(0, 3));
                currentPlayer = Toggle(currentPlayer);
            }
            while (!gameBoard.GameIsOver());
            

            console.ReadKey();
        }

        private static char Toggle(char currentPlayer)
        {
            return currentPlayer == 'X' ? 'O' : 'X';
        }
    }
}