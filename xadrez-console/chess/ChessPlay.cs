using board;
using System;
using System.Collections.Generic;

namespace chess
{
    class ChessPlay
    {
        public Board board { get; private set; }
        public int turn { get; private set; }
        public Color actualPlayer { get; private set; }
        public bool hasFinish { get; private set; }
        public bool isCheck { get; private set; }
        private HashSet<Piece> pieces;
        private HashSet<Piece> deadPieces;

        public ChessPlay()
        {
            board = new Board(8, 8);
            turn = 1;
            actualPlayer = Color.white;
            hasFinish = false;
            isCheck = false;
            pieces = new HashSet<Piece>();
            deadPieces = new HashSet<Piece>();
            setTable();
        }

        private Piece doMovement(Position origin, Position destiny)
        {
            Piece p = board.removePiece(origin);
            p.increaseMovement();
            Piece deadPiece = board.removePiece(destiny);
            board.addPiece(p, destiny);
            if (deadPiece != null)
                deadPieces.Add(deadPiece);

            return deadPiece;
        }

        private void undoMovement(Position origin, Position destiny, Piece deadPiece)
        {
            Piece p = board.removePiece(destiny);
            p.decreaseMovement();
            if (deadPiece != null)
            {
                board.addPiece(deadPiece, destiny);
                deadPieces.Remove(deadPiece);
            }
            board.addPiece(p, origin);

        }

        public void makeMove(Position origin, Position destiny)
        {
            Piece deadPiece = doMovement(origin, destiny);
            if (isInCheck(actualPlayer))
            {
                undoMovement(origin, destiny, deadPiece);
                throw new BoardException("You can not put yourself in check");
            }

            if (isInCheck(getChessMateColor(actualPlayer)))
            {
                isCheck = true;
            }
            else
            {
                isCheck = false;
            }
            if (isCheckmate(getChessMateColor(actualPlayer)))
            {
                hasFinish = true;
            }
            else
            {
                turn++;
                changePlayer();
            }
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

        private Color getChessMateColor(Color c)
        {
            if (c == Color.black)
            {
                return Color.white;
            }
            else
            {
                return Color.black;
            }
        }

        private Piece getKing(Color c)
        {
            foreach (Piece p in getLivePieces(c))
            {
                if (p is King)
                {
                    return p;

                };
            }
            return null;

        }

        public bool isInCheck(Color c)
        {
            Piece k = getKing(c);
            /*if (k == null)
            {
                throw new BoardException($"There is no king of color #{c}");
            }*/

            foreach (Piece p in getLivePieces(getChessMateColor(c)))
            {
                bool[,] m = p.possibleMovements();
                if (m[k.position.line, k.position.column])
                {
                    return true;
                }
            }
            return false;
        }

        public bool isCheckmate(Color c)
        {
            if (!isInCheck(c))
            {
                return false;
            }
            foreach (Piece p in getLivePieces(c))
            {
                bool[,] m = p.possibleMovements();
                for (int i = 0; i < board.qtLines; i++)
                {
                    for (int j = 0; j < board.qtColumns; j++)
                    {
                        Position origin = p.position;
                        Piece deadPiece = doMovement(p.position, new Position(i, j));
                        bool testCheck = isInCheck(c);
                        undoMovement(origin, new Position(i, j), deadPiece);
                        if (!testCheck)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
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

           // addNewPiece('c', 7, new Rook(board, Color.black));
           // addNewPiece('c', 8, new Rook(board, Color.black));
            //addNewPiece('d', 7, new Rook(board, Color.black));
           // addNewPiece('e', 7, new Rook(board, Color.black));
            addNewPiece('e', 8, new Rook(board, Color.black));
            addNewPiece('d', 8, new King(board, Color.black));
        }
    }
}
