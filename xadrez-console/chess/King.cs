using System;
using board;

namespace chess
{
    class King : Piece
    {
        private ChessPlay play;

        public King(Board b, Color color, ChessPlay play) : base(b, color)
        {
            this.play = play;
        }
        public override string ToString()
        {
            return "R";
        }

        private bool canRookCastling(Position pos)
        {
            Piece p = board.getPiece(pos);
            return p != null && p is Rook && p.color == color && qtMovements == 0;
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



            //jogadas especiais 
            if (qtMovements == 0 && !play.isCheck)
            {
                //roque pequeno
                Position rookPositionKingside = new Position(position.line, position.column + 3);
                if (canRookCastling(rookPositionKingside))
                {
                    Position p1 = new Position(position.line, position.column + 1);
                    Position p2 = new Position(position.line, position.column + 2);
                    if (board.getPiece(p1) == null && board.getPiece(p2) == null)
                    {
                        m[position.line, position.column + 2] = true;
                    }
                }

                //roque grande 
                Position rookPositionQueenside = new Position(position.line, position.column - 4);
                if (canRookCastling(rookPositionQueenside))
                {
                    Position p1 = new Position(position.line, position.column - 1);
                    Position p2 = new Position(position.line, position.column - 2);
                    Position p3 = new Position(position.line, position.column - 3);
                    if (board.getPiece(p1) == null && board.getPiece(p2) == null && board.getPiece(p3) == null)
                    {
                        m[position.line, position.column - 2] = true;
                    }
                }

            }

            return m;


        }


    }
}
