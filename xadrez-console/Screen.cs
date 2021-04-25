using board;
using chess;
using System;
using System.Collections.Generic;

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
                    showPiece(b.getPiece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        internal static void showPlayInfo(ChessPlay play)
        {
            Console.WriteLine();
            showBoard(play.board);
            Console.WriteLine();
            Console.WriteLine($"Turno: #{play.turn}");

            if (!play.hasFinish)
            {

                Console.WriteLine($"Jogador: #{play.actualPlayer}");
                if (play.isCheck)
                {
                    Console.WriteLine("Xeque");
                }
                showDeadPieces(play);
            } else
            {
                Console.WriteLine("Xequemate");
                Console.WriteLine($"O jogador vencedor foi o #{play.actualPlayer}");

            }
        }

        public static void showDeadPieces(ChessPlay play)
        {
            Console.WriteLine("Peças mortas: ");
            Console.Write("Brancas: ");
            showSet(play.getDeadPieces(Color.white));

            ConsoleColor auxColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write("Pretas: ");
            showSet(play.getDeadPieces(Color.black));
            Console.ForegroundColor = auxColor;
        }

        public static void showSet(HashSet<Piece> pieces)
        {
            Console.Write("[");
            foreach (Piece p in pieces)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }

        public static void showBoard(Board b, bool[,] m)
        {
            ConsoleColor originalColor = Console.BackgroundColor;
            ConsoleColor newColor = ConsoleColor.DarkGray;
            for (int i = 0; i < b.qtLines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < b.qtColumns; j++)
                {
                    if (m[i, j] == true)
                    {
                        Console.BackgroundColor = newColor;
                    }
                    else
                    {
                        Console.BackgroundColor = originalColor;
                    }
                    showPiece(b.getPiece(i, j));
                    Console.BackgroundColor = originalColor;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalColor;
        }

        public static ChessPosition readPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void showPiece(Piece p)
        {
            if (p == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
