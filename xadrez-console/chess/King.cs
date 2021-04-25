using System;
using board;

namespace chess
{
    class King : Piece
    {


        public King(Board b, Color color) : base(b, color)
        {

        }
        public override string ToString()
        {
            return "R";
        }

        public override bool[,] possibleMovements()
        {
            bool[,] m = new bool[board.qtLines, board.qtColumns];

            Position pos = new Position(0, 0);

            //cima
            pos.defineValues(position.line - 1, position.column);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

            //superior direito
            pos.defineValues(position.line - 1, position.column + 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

            //direito
            pos.defineValues(position.line, position.column + 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

            //inferior direito
            pos.defineValues(position.line + 1, position.column + 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

            //baixo
            pos.defineValues(position.line + 1, position.column);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

            //inferior esquerdo
            pos.defineValues(position.line + 1, position.column - 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

            //esquerdo
            pos.defineValues(position.line, position.column - 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }

            //superior esquerdo
            pos.defineValues(position.line - 1, position.column - 1);
            if (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
            }
            return m;


        }


    }
}
