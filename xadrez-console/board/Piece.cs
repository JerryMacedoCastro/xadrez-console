namespace board
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int qtMovements {get; set;}
        public Board board { get; set; }

        public Piece(Position position, Color color,  Board board)
        {
            this.position = position;
            this.color = color;
            this.qtMovements = 0;
            this.board = board;
        }
    }
}
