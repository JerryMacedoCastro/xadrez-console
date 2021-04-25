using board;
using System;

namespace chess
{
    class ChessPlay
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color actualPlayer { get; private set; }
        public bool hasFinish { get; private set; }

        public ChessPlay()
        {
            board = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.white;
            hasFinish = false;
            setTable();
        }

        private void doMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.increaseMovement();
            Piece deadPiece = board.removePiece(destiny);
            board.addPiece(p, destiny);
        }

        public void makeMove(Position origin, Position destiny)
        {
            doMovement(origin, destiny);
            turn++;
            changePlayer();
        }

        public void validateOriginPosition(Position pos)
        {
            if (board.getPiece(pos) == null)
                throw new BoardException("Tehere is no piece on this position");
            if (actualPlayer != board.getPiece(pos).color)
                throw new BoardException("you can not move this piece");
            if (!board.getPiece(pos).hasPossibleMovements())
                throw new BoardException("This piece is blocked");
        }

        public void validateDestinyPosition(Position origin, Position destiny)
        {
            if (!board.getPiece(origin).canMoveTo(destiny))
                throw new BoardException("Invalid destiny");
        }

        private void changePlayer()
        {
            if (actualPlayer == Color.white)
                actualPlayer = Color.black;
            else
                actualPlayer = Color.white;
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
