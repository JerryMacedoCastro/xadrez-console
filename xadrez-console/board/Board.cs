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
    }


}
