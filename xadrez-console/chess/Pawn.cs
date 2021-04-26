using board;

namespace chess
{
    class Pawn : Piece
    {
        private ChessPlay play;
        public Pawn(Board board, Color color, ChessPlay play) : base(board, color)
        {
            this.play = play;
        }

        public override string ToString()
        {
            return "P";
        }

        private bool hasEnemy(Position pos)
        {
            Piece p = board.getPiece(pos);
            return p != null && p.color != color;
        }

        private bool isFreePosition(Position pos)
        {
            return board.getPiece(pos) == null;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] m = new bool[board.qtLines, board.qtColumns];

            Position pos = new Position(0, 0);

            if (color == Color.white)
            {
                pos.defineValues(position.line - 1, position.column);
                if (board.isValidPosition(pos) && isFreePosition(pos))
                {
                    m[pos.line, pos.column] = true;
                }

                pos.defineValues(position.line - 2, position.column);
                if (board.isValidPosition(pos) && isFreePosition(pos) && qtMovements == 0)
                {
                    m[pos.line, pos.column] = true;
                }

                pos.defineValues(position.line - 1, position.column + 1);
                if (board.isValidPosition(pos) && hasEnemy(pos))
                {
                    m[pos.line, pos.column] = true;
                }

                pos.defineValues(position.line - 1, position.column - 1);
                if (board.isValidPosition(pos) && hasEnemy(pos))
                {
                    m[pos.line, pos.column] = true;
                }

                //#jogadaespecial en passant
                if (position.line == 3)
                {
                    Position leftPos = new Position(position.line, position.column - 1);
                    if (board.isValidPosition(leftPos) && hasEnemy(leftPos) && board.getPiece(leftPos) == play.canSufferEnPassant)
                    {
                        m[leftPos.line - 1, leftPos.column] = true;
                    }

                    Position rightPos = new Position(position.line, position.column + 1);
                    if (board.isValidPosition(rightPos) && hasEnemy(rightPos) && board.getPiece(rightPos) == play.canSufferEnPassant)
                    {
                        m[rightPos.line -1, rightPos.column] = true;
                    }

                }

            }
            else
            {
                pos.defineValues(position.line + 1, position.column);
                if (board.isValidPosition(pos) && isFreePosition(pos))
                {
                    m[pos.line, pos.column] = true;
                }

                pos.defineValues(position.line + 2, position.column);
                if (board.isValidPosition(pos) && isFreePosition(pos) && qtMovements == 0)
                {
                    m[pos.line, pos.column] = true;
                }

                pos.defineValues(position.line + 1, position.column + 1);
                if (board.isValidPosition(pos) && hasEnemy(pos))
                {
                    m[pos.line, pos.column] = true;
                }

                pos.defineValues(position.line + 1, position.column - 1);
                if (board.isValidPosition(pos) && hasEnemy(pos))
                {
                    m[pos.line, pos.column] = true;
                }


                //#jogadaespecial en passant
                if (position.line == 4)
                {
                    Position leftPos = new Position(position.line, position.column - 1);
                    if (board.isValidPosition(leftPos) && hasEnemy(leftPos) && board.getPiece(leftPos) == play.canSufferEnPassant)
                    {
                        m[leftPos.line + 1, leftPos.column] = true;
                    }

                    Position rightPos = new Position(position.line, position.column + 1);
                    if (board.isValidPosition(rightPos) && hasEnemy(rightPos) && board.getPiece(rightPos) == play.canSufferEnPassant)
                    {
                        m[rightPos.line +  1, rightPos.column] = true;
                    }

                }
            }


            return m;
        }


    }
}
