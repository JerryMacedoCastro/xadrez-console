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
            if (!board.getPiece(origin).possibleMovement(destiny))
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

        public Piece getKing(Color c)
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

            if (k == null)
            {
                throw new BoardException($"There is no king of color #{c}");
            }

            foreach (Piece p in getLivePieces(getChessMateColor(c)))
            {
                bool[,] m = p.possibleMovements();
                if (m[k.position.line, k.position.column] == true)
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
                        if (m[i, j])
                        {
                            Position origin = p.position;
                            Position destiny = new Position(i, j);
                            Piece deadPiece = doMovement(p.position, destiny);
                            bool testCheck = isInCheck(c);
                            undoMovement(origin, destiny, deadPiece);
                            if (!testCheck)
                            {
                                return false;
                            }
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
           

            addNewPiece('a', 1, new Rook(board, Color.white));
            addNewPiece('b', 1, new Knight(board, Color.white));
            addNewPiece('c', 1, new Bishop(board, Color.white));
            addNewPiece('d', 1, new Queen(board, Color.white));
            addNewPiece('e', 1, new King(board, Color.white));
            addNewPiece('f', 1, new Bishop(board, Color.white));
            addNewPiece('g', 1, new Knight(board, Color.white));
            addNewPiece('h', 1, new Rook(board, Color.white));
            
            addNewPiece('a', 2, new Pawn(board, Color.white));
            addNewPiece('b', 2, new Pawn(board, Color.white));
            addNewPiece('c', 2, new Pawn(board, Color.white));
            addNewPiece('d', 2, new Pawn(board, Color.white));
            addNewPiece('e', 2, new Pawn(board, Color.white));
            addNewPiece('f', 2, new Pawn(board, Color.white));
            addNewPiece('g', 2, new Pawn(board, Color.white));
            addNewPiece('h', 2, new Pawn(board, Color.white));


            addNewPiece('a', 7, new Pawn(board, Color.black));
            addNewPiece('b', 7, new Pawn(board, Color.black));
            addNewPiece('c', 7, new Pawn(board, Color.black));
            addNewPiece('d', 7, new Pawn(board, Color.black));
            addNewPiece('e', 7, new Pawn(board, Color.black));
            addNewPiece('f', 7, new Pawn(board, Color.black));
            addNewPiece('g', 7, new Pawn(board, Color.black));
            addNewPiece('h', 7, new Pawn(board, Color.black));

            addNewPiece('a', 8, new Rook(board, Color.black));
            addNewPiece('b', 8, new Knight(board, Color.black));
            addNewPiece('c', 8, new Bishop(board, Color.black));
            addNewPiece('d', 8, new Queen(board, Color.black));
            addNewPiece('e', 8, new King(board, Color.black));
            addNewPiece('f', 8, new Bishop(board, Color.black));
            addNewPiece('g', 8, new Knight(board, Color.black));
            addNewPiece('h', 8, new Rook(board, Color.black));



        }
    }
}
