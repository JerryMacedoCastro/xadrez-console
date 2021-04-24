using board;
using chess;
using System;

namespace xadrez_console
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessPosition chessPosition = new ChessPosition('c', 7);
                Console.WriteLine(chessPosition.toPosition());
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
