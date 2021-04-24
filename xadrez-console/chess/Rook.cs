using System;
using board;

namespace chess
{
    class Rook : Piece
    {
        public Rook(Board b, Color color) : base(b, color)
        {

        }
        public override string ToString()
        {
            return "T";
        }
    }
}
