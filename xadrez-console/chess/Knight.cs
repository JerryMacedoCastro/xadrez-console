using board;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chess
{
    class Knight : Piece
    {
        public Knight(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            return "C";
        }

        public bool canMove(Position pos)
        {
            Piece p = board.getPiece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] m = new bool[board.qtLines, board.qtColumns];
            Position pos = new Position(0, 0);

            //acima
            pos.defineValues(position.line - 1, position.column - 2);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

           
            pos.defineValues(position.line - 2, position.column - 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

          
            pos.defineValues(position.line - 2, position.column + 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

           
            pos.defineValues(position.line - 1, position.column + 2);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }


            //movimentos para baixo

            
            pos.defineValues(position.line + 1, position.column + 2);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

           
            pos.defineValues(position.line + 2, position.column + 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

          
            pos.defineValues(position.line + 2, position.column - 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

            pos.defineValues(position.line + 1, position.column - 2 );
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }


            return m;
        }


    }
}
