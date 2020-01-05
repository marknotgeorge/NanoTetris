using System.Drawing;

namespace TetrisEngine
{
    /// <summary>
    /// The L-shaped piece.
    /// </summary>
    internal class LimaPiece : Piece
    {
        public LimaPiece()
        {
            Type = PieceType.Lima;
            Color = Color.Green;

            // Stored as numbers for concise code.
            // NoBlock = 0; Normal = 1; Pivot = 2;
            blocks = new int[4, 5, 5]
            {
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 2, 0, 0},
                    {0, 0, 1, 1, 0},
                    {0, 0, 0, 0, 0}
                    },
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 1, 2, 1, 0},
                    {0, 1, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                    },
                {
                    {0, 0, 0, 0, 0},
                    {0, 1, 1, 0, 0},
                    {0, 0, 2, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                    },
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 1, 0},
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