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
                for (int j = 0; j < b.qtColumns; j++)
                {
                    if (b.getPiece(i, j) == null)
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(b.getPiece(i, j));
                    }

                }
                Console.WriteLine();
            }
        }
    }
}
