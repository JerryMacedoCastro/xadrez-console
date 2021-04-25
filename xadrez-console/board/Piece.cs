namespace board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtMovements { get; set; }
        public Board board { get; set; }

        public Piece(Board board, Color color)
        {
            this.board = board;
            this.color = color;
            this.position = null;
            this.qtMovements = 0;
        }

        public void increaseMovement()
        {
            qtMovements++;
        }

        public void decreaseMovement()
        {
            qtMovements--;
        }

        public bool canMove(Position pos)
        {
            Piece p = board.getPiece(pos);
            return p == null || p.color != color;
        }

        public bool hasPossibleMovements()
        {
            bool[,] m = possibleMovements();

            for (int i = 0; i < board.qtLines; i++)
            {
                for (int j = 0; j < board.qtColumns; j++)
                {
                    if (m[i, j] == true) return true;
                }
            }
            return false;
        }

        public bool possibleMovement(Position pos)
        {
            return possibleMovements()[pos.line, pos.column];
        }
        public abstract bool[,] possibleMovements();
    }
}
