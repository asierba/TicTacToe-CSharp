namespace NoughtsAndCrosses
{
    using System.Threading;

    public class Application
    {
        private readonly IConsole console;

        private readonly IGameBoard gameBoard;

        private readonly Player player1;

        private readonly Player player2;

        public Application(IConsole console, IGameBoard gameBoard)
        {
            this.console = console;
            this.gameBoard = gameBoard;
            player1 = new Player('X');
            player2 = new Player('O');
        }

        public void Run()
        {
            console.WriteLine("");
            console.WriteLine("Tic-Tac-Toe Game");
            console.WriteLine("================");
            console.WriteLine("");

            console.WriteLine("Press Any Key to begin the game");
            console.WriteLine("");
            console.ReadKey();

            var currentPlayer = player1;
            do
            {
                console.WriteLine("Game Board:");
                console.WriteLine(gameBoard.Display());

                var position = currentPlayer.NextMove(gameBoard);
                gameBoard.Move(currentPlayer, position);
                currentPlayer = Toggle(currentPlayer);
                
                Thread.Sleep(1000);
            }
            while (!gameBoard.GameIsOver());
            
            console.WriteLine(gameBoard.Display());
            console.WriteLine("GAME OVER!!");
            console.WriteLine(gameBoard.Result);
        }

        private Player Toggle(Player currentPlayer)
        {
            return currentPlayer == player1 ? player2 : player1;
        }
    }
}