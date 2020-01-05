namespace TetrisEngine
{
    public class Piece
    {
        // [Rotation][Horizontal][Vertical]
        internal int[,,] blocks;

        // [Horizontal][Vertical]
        internal int[,] initialTransform;

        // <summary>
        /// The number of Blocks in a Piece
        /// </summary>/
        public readonly int BlockCount = 5;

        public PieceType Type { get; set; }
        public PieceRotation Rotation { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public bool IsNextPiece { get; set; }

        public ColorRGB Color { get; set; }

        public static Piece GetPiece(PieceType type, PieceRotation rotation, bool isNextPiece = true)
        {
            Piece returnPiece = null;
            switch (type)
            {
                case PieceType.Indigo:
                    returnPiece = new IndigoPiece();
                    break;

                case PieceType.Oscar:
                    returnPiece = new OscarPiece();
                    break;

                case PieceType.Tango:
                    returnPiece = new TangoPiece();
                    break;

                case PieceType.Sierra:
                    returnPiece = new SierraPiece();
                    break;

                case PieceType.Zulu:
                    returnPiece = new ZuluPiece();
                    break;

                case PieceType.Juliet:
                    returnPiece = new JulietPiece();
                    break;

                case PieceType.Lima:
                    returnPiece = new LimaPiece();
                    break;
            }

            returnPiece.Rotation = rotation;
            returnPiece.IsNextPiece = isNextPiece;

            return returnPiece;
        }

        public PieceBlock GetBlock(int x, int y)
        {
            return (PieceBlock)blocks[(int)Rotation, x, y];
        }

        public Position GetInitialPosition()
        {
            return new Position(initialTransform[(int)Rotation, 0], initialTransform[(int)Rotation, 1]);
        }
    }

    public enum PieceType
    {
        Indigo = 0,
        Oscar,
        Tango,
        Sierra,
        Zulu,
        Juliet,
        Lima
    }

    public enum PieceRotation
    {
        Zero = 0,
        Ninety,
        OneEighty,
        TwoSeventy
    }

    public enum PieceBlock
    {
        NoBlock = 0,
        Normal = 1,
        Pivot = 2
    }
}