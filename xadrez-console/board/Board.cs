namespace board
{
    class Board
    {
        public int qtLines { get; set; }
        public int qtColumns { get; set; }

        private Piece[,] pieces;

        public Board(int qtLines, int qtColumns)
        {
            this.qtLines = qtLines;
            this.qtColumns = qtColumns;
            pieces = new Piece[qtLines, qtColumns];
        }
        public Piece getPiece(int line, int column)
        {
            return pieces[line, column];
        }
        public Piece getPiece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }
        public void addPiece(Piece p, Position pos)
        {
            if (hasPiece(pos))
                throw new BoardException("Already exists a piece on this position");
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }
        public bool hasPiece(Position pos)
        {
            validatePosition(pos);
            if (getPiece(pos) != null)
                return true;
            return false;
        }

        public bool isValidPosition(Position pos)
        {
            if (pos.line < 0 || pos.line >= qtLines || pos.column < 0 || pos.column >= qtColumns)
            {
                return false;
            }
            return true;
        }

        public void validatePosition(Position pos)
        {
            if (!isValidPosition(pos))
            {
                throw new BoardException("invalid position");
            };
        }
    }


}
