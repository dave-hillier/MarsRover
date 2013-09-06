using System;

namespace MarsRover
{
    public class Program
    {
        static void Main()
        {
            var i = new Interpreter();
            i.Run(Console.In, Console.Out);
        }
    }
}
