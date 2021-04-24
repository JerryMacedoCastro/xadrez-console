using board;
using System;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Position p = new Position(2, 4);

            Console.WriteLine(p.ToString());
        }
    }
}
