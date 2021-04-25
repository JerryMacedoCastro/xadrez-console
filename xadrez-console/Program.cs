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
                        Screen.showPlayInfo(play);
                        
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
                Console.Clear();
                Screen.showPlayInfo(play);


            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
