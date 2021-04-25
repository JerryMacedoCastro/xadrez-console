using board;
using System.Collections.Generic;

namespace chess
{
    class ChessPlay
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color actualPlayer { get; private set; }
        public bool hasFinish { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> deadPieces;

        public ChessPlay()
        {
            board = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.white;
            hasFinish = false;
            pieces = new HashSet<Piece>();
            deadPieces = new HashSet<Piece>();
            setTable();
        }

        private void doMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.increaseMovement();
            Piece deadPiece = board.removePiece(destiny);
            board.addPiece(p, destiny);
            if (deadPiece != null)
                deadPieces.Add(deadPiece);
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

        public HashSet<Piece> getDeadPieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in deadPieces)
            {
                if (p.color == color)
                    aux.Add(p);
            }
            return aux;
        }
        public HashSet<Piece> getLivePieces(Color color)
        {
            HashSet<Piece> aux = new HashSet<Piece>();
            foreach (Piece p in pieces)
            {
                if (p.color == color)
                    aux.Add(p);
            }
            aux.ExceptWith(deadPieces);
            return aux;
        }


        public void addNewPiece(char col, int line, Piece p)
        {
            board.addPiece(p, new ChessPosition(col, line).toPosition());
            pieces.Add(p);
        }

        private void setTable()
        {
            addNewPiece('c', 1, new Rook(board, Color.white));
            addNewPiece('c', 2, new Rook(board, Color.white));
            addNewPiece('d', 2, new Rook(board, Color.white));
            addNewPiece('e', 1, new Rook(board, Color.white));
            addNewPiece('e', 2, new Rook(board, Color.white));
            addNewPiece('d', 1, new King(board, Color.white));

            addNewPiece('c', 7, new Rook(board, Color.black));
            addNewPiece('c', 8, new Rook(board, Color.black));
            addNewPiece('d', 7, new Rook(board, Color.black));
            addNewPiece('e', 7, new Rook(board, Color.black));
            addNewPiece('e', 8, new Rook(board, Color.black));
            addNewPiece('d', 8, new King(board, Color.black));
        }
    }
}
