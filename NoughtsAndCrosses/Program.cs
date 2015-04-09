using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoughtsAndCrosses
{
    using System.Threading;

    public class Program
    {
        public static void Main(string[] args)
        {
            var app = new App(new ConsoleWrapper());
        }
    }
}
