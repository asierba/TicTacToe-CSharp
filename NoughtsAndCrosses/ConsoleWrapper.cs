namespace NoughtsAndCrosses
{
    using System;

    // TODO better name
    public class ConsoleWrapper : IConsole
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public void ReadKey()
        {
            Console.ReadKey();
        }
    }
}