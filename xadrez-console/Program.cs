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

                    Console.Clear();
                    Screen.showBoard(play.board);

                    Console.WriteLine("origem: ");
                    Position origin = Screen.readPosition().toPosition();
                    Console.WriteLine("destino: ");
                    Position destiny = Screen.readPosition().toPosition();

                    play.doMovement(origin, destiny);


                }


            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
