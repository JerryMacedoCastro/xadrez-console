﻿using System;
using board;

namespace chess
{
    class Queen : Piece
    {
        public Queen(Board board, Color color) : base(board, color)
        {
        }

        public override string ToString()
        {
            //D para nao confundir com o rei
            return "D";
        }

        public bool canMove(Position pos)
        {
            Piece p = board.getPiece(pos);
            return p == null || p.color != color;
        }

        public override bool[,] possibleMovements()
        {
            bool[,] m = new bool[board.qtLines, board.qtColumns];
            Position pos = new Position(0, 0);

            //acima
            pos.defineValues(position.line - 1, position.column);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line -= 1;
            }

            //abaixo
            pos.defineValues(position.line + 1, position.column);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line += 1;
            }

            //direita
            pos.defineValues(position.line, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.column += 1;
            }

            //esquerda
            pos.defineValues(position.line, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.column -= 1;
            }

            //superior esquerdo
            pos.defineValues(position.line - 1, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line -= 1;
                pos.column -= 1;
            }


            //superior direito
            pos.defineValues(position.line - 1, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line -= 1;
                pos.column += 1;
            }

            //inferior esquerdo
            pos.defineValues(position.line + 1, position.column - 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line += 1;
                pos.column -= 1;
            }

            //inferior direito
            pos.defineValues(position.line + 1, position.column + 1);
            while (board.isValidPosition(pos) && canMove(pos))
            {
                m[pos.line, pos.column] = true;
                if (board.getPiece(pos) != null && board.getPiece(pos).color != color)
                {
                    break;
                }
                pos.line += 1;
                pos.column += 1;
            }


            return m;
        }

    }
}
