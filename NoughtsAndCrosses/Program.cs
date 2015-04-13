using System;

namespace NoughtsAndCrosses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string answer;
            do
            {
                var app = new Application(new ConsoleWrapper(), new GameBoard());
                app.Run();

                Console.WriteLine();
                Console.WriteLine("Do you want to play anothger game? (y/n)");
                answer = Console.ReadLine();
                
            } while (answer == "y");

            Console.WriteLine("Bye!");
            Console.ReadKey();
        }
    }
}
