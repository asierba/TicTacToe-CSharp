namespace NoughtsAndCrosses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new Application(new ConsoleWrapper(), new GameBoard());
            app.Run();
        }
    }
}
