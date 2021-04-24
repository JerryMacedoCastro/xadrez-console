namespace board
{
    class Board
    {
        public int qtLines { get; set; }
        public int qtColumns { get; set; }

        private Piece[,] pieces;
        /// <summary>
        /// new board
        /// </summary>
        /// <param name="qtLines"></param>
        /// <param name="qtColumns"></param>
        public Board(int qtLines, int qtColumns)
        {
            this.qtLines = qtLines;
            this.qtColumns = qtColumns;
            pieces = new Piece[qtLines, qtColumns];
        }

        /// <summary>
        /// returns the piece in the given line and column
        /// </summary>
        /// <param name="line"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public Piece getPiece(int line, int column)
        {
            return pieces[line, column];
        }
        /// <summary>
        /// returns the piece in the given position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Piece getPiece(Position pos)
        {
            return pieces[pos.line, pos.column];
        }
        /// <summary>
        /// adds a piece "p" in the given position
        /// </summary>
        /// <param name="p"></param>
        /// <param name="pos"></param>
        public void addPiece(Piece p, Position pos)
        {
            if (hasPiece(pos))
                throw new BoardException("Already exists a piece on this position");
            pieces[pos.line, pos.column] = p;
            p.position = pos;
        }

        /// <summary>
        /// removes the piece from the board and returns the removed piece (when exists)
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public Piece removePiece(Position pos)
        {
            if (getPiece(pos) == null)
                return null;

            Piece auxPiece = getPiece(pos);
            pieces[pos.line, pos.column] = null;
            return auxPiece;
        }
        /// <summary>
        /// returns "true" if exists a piece in the given position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool hasPiece(Position pos)
        {
            validatePosition(pos);
            if (getPiece(pos) != null)
                return true;
            return false;
        }

        /// <summary>
        /// returns true if the position is valid for the board
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool isValidPosition(Position pos)
        {
            if (pos.line < 0 || pos.line >= qtLines || pos.column < 0 || pos.column >= qtColumns)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// validate if the position is valid
        /// </summary>
        /// <param name="pos"></param>
        public void validatePosition(Position pos)
        {
            if (!isValidPosition(pos))
            {
                throw new BoardException("invalid position");
            };
        }
    }


}
