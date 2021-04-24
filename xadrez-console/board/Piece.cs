namespace board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtMovements {get; set;}
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
    }
}
