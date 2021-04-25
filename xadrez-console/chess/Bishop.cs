using board;


namespace chess
{
    class Bishop : Piece
    {
        public Bishop(Board board, Color color) : base(board, color)
        {
        }
        public override string ToString()
        {
            return "B";
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

            //superior esquerdo
            pos.defineValues(position.line - 1, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line -= 1;
                pos.column -= 1;
            }


            //superior direito
            pos.defineValues(position.line - 1, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line -= 1;
                pos.column += 1;
            }

            //inferior esquerdo
            pos.defineValues(position.line + 1, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line += 1;
                pos.column -= 1;
            }

            //inferior direito
            pos.defineValues(position.line + 1, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line += 1;
                pos.column += 1;
            }

            return m;
        }
    }
}
