using board;
using System;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Board b = new Board(8, 8);
            Screen.showBoard(b);
            Console.WriteLine("Hey ho ");
        }
    }
}
