namespace NoughtsAndCrosses
{
    public class Application
    {
        private readonly IConsole console;

        public Application(IConsole console)
        {
            this.console = console;
        }

        public void Run()
        {
            console.WriteLine("Tic-Tac-Toe Game");
            console.WriteLine("================");

            console.WriteLine("Press Any Key to begin the game");

            console.ReadKey();

            console.WriteLine("Game Board:");
            var gameBoard = new GameBoard();
            console.WriteLine(gameBoard.Display());

            console.ReadKey();
        }
    }
}