using System.Drawing;

namespace TetrisEngine
{
    internal class TangoPiece : Piece
    {
        public TangoPiece()
        {
            Type = PieceType.Tango;
            Color = Color.Orange;

            blocks = new int[4, 5, 5]
            {
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 2, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 1, 2, 1, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 2, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 1, 2, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                }
            };

            initialTransform = new int[4, 2]
            {
                {-2, -3},
                {-2, -3},
                {-2, -3},
                {-2, -2}
            };
        }
    }
}