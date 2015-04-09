namespace NoughtsAndCrosses
{
    using System;

    public class App
    {
        public App(IConsole console)
        {
            console.WriteLine("Tic-Tac-Toe Game");
            console.WriteLine("================");

            console.WriteLine("Press Any Key to begin the game");

            console.ReadKey();
        }
    }
}