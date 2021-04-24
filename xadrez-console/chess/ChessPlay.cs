using board;
using System;

namespace chess
{
    class ChessPlay
    {
        public Board board { get; private set; }
        private int turn;
        private Color actualPlayer;
        public bool hasFinish { get; private set; }

        public ChessPlay()
        {
            board = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.white;
            hasFinish = false;
            setTable();
        }

        public void doMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.increaseMovement();
            Piece deadPiece = board.removePiece(destiny);
            board.addPiece(p, destiny);
        }

        private void setTable()
        {
            board.addPiece(new Rook(board, Color.white), new ChessPosition('c', 1).toPosition());
            board.addPiece(new Rook(board, Color.white), new ChessPosition('c', 2).toPosition());
            board.addPiece(new Rook(board, Color.white), new ChessPosition('d', 2).toPosition());
            board.addPiece(new Rook(board, Color.white), new ChessPosition('e', 1).toPosition());
            board.addPiece(new Rook(board, Color.white), new ChessPosition('e', 2).toPosition());
            board.addPiece(new King(board, Color.white), new ChessPosition('d', 1).toPosition());

            board.addPiece(new Rook(board, Color.black), new ChessPosition('c', 7).toPosition());
            board.addPiece(new Rook(board, Color.black), new ChessPosition('c', 8).toPosition());
            board.addPiece(new Rook(board, Color.black), new ChessPosition('d', 7).toPosition());
            board.addPiece(new Rook(board, Color.black), new ChessPosition('e', 7).toPosition());
            board.addPiece(new Rook(board, Color.black), new ChessPosition('e', 8).toPosition());
            board.addPiece(new King(board, Color.black), new ChessPosition('d', 8).toPosition());
        }
    }
}
