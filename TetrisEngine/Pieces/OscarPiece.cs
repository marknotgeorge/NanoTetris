using System.Drawing;

namespace TetrisEngine
{
    /// <summary>
    /// The square piece.
    /// </summary>
    internal class OscarPiece : Piece
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="rotation">The piece's initial rotation</param>
        public OscarPiece()
        {
            Type = PieceType.Oscar;
            Color = Color.Brown;

            // Stored as numbers for concise code.
            // NoBlock = 0; Normal = 1; Pivot = 2;
            blocks = new int[4,5,5]
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
                {-2, -3}
            };

        }
    }
}