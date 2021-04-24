using System;
using board;

namespace chess
{
    class King : Piece
    {
        public King(Board b, Color color) : base(b, color)
        {

        }
        public override string ToString()
        {
            return "R";
        }
    }
}
