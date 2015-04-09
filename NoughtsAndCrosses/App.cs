namespace NoughtsAndCrosses
{
    public class App
    {
        public App(IConsole console)
        {
            console.WriteLine("Tic-Tac-Toe Game");
            console.WriteLine("================");

            console.WriteLine("Press Any Key to begin the game");

            console.ReadKey();

            console.WriteLine("Game Board:");
            console.WriteLine("[ ] [ ] [ ]\n[ ] [ ] [ ]\n[ ] [ ] [ ]");

            console.ReadKey();
        }
    }
}