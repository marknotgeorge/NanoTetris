using System.Drawing;

namespace TetrisEngine
{
    public class IndigoPiece : Piece
    {
        public IndigoPiece()
        {
            Type = PieceType.Indigo;
            Color = Color.Indigo;
            
            blocks = new int[4, 5, 5]
            {
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {0, 1, 2, 1, 1},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 1, 0, 0}, 
                    {0, 0, 2, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0}
                },
                {
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0},
                    {1, 1, 2, 1, 0},
                    {0, 0, 0, 0, 0},
                    {0, 0, 0, 0, 0}
                },
                {
                    {0, 0, 1, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 2, 0, 0},
                    {0, 0, 1, 0, 0},
                    {0, 0, 0, 0, 0}
                }                
            };

            initialTransform = new int[4, 2]
            {
                {-2, -2},
                {-2, -3},
                {-2, -2},
                {-2, -3}
            };
        }
    }
}