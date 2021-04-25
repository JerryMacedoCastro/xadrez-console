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
                ChessPlay play = new ChessPlay();
                while (!play.hasFinish)
                {

                    try
                    {
                        Console.Clear();
                        Screen.showBoard(play.board);
                        Console.WriteLine();
                        Console.WriteLine($"Turno: #{play.turn}");
                        Console.WriteLine($"Jogador: #{play.actualPlayer}");

                        Console.WriteLine();
                        Console.WriteLine("origem: ");
                        Position origin = Screen.readPosition().toPosition();
                        play.validateOriginPosition(origin);


                        bool[,] possiblePositions = play.board.getPiece(origin).possibleMovements();

                        Console.Clear();
                        Screen.showBoard(play.board, possiblePositions);

                        Console.WriteLine();
                        Console.WriteLine("destino: ");
                        Position destiny = Screen.readPosition().toPosition();
                        play.validateDestinyPosition(origin, destiny);

                        play.makeMove(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                    }
                }


            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
