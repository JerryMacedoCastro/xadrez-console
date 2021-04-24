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
                Board b = new Board(8, 8);
                b.addPiece(new Rook(b, Color.black), new Position(0, 0));
                b.addPiece(new Rook(b, Color.black), new Position(1, 3));
                b.addPiece(new King(b, Color.black), new Position(8, 3));
                Screen.showBoard(b);
            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
