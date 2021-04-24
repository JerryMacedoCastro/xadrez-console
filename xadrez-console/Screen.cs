using board;
using System;

namespace xadrez_console
{
    class Screen
    {
        public static void showBoard(Board b)
        {
            for (int i = 0; i < b.qtLines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < b.qtColumns; j++)
                {
                    if (b.getPiece(i, j) == null)
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Screen.showPiece(b.getPiece(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void showPiece(Piece p)
        {
            if (p.color == Color.white)
            {
                Console.Write(p);
            }
            else
            {
                ConsoleColor auxColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(p);
                Console.ForegroundColor = auxColor;
            }
        }
    }
}
