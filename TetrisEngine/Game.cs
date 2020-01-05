using System;

namespace TetrisEngine
{
    public class Game
    {
        private IDisplay _display;
        private Board _board;

        public Piece CurrentPiece;
        private Piece nextPiece;

        private readonly byte typeCount = 7;
        private readonly byte rotationCount = 4;

        private int waitTime = 700;

        public Game(IDisplay display)
        {
            _display = display;
            _board = new Board(display.BoardWidthInBlocks(), display.BoardHeightInBlocks());

            CreateNewPiece(true);
        }

        public void CreateNewPiece(bool createBoth = false)
        {
            var randGen = new Random();
            Position initPos;

            if (createBoth)
            {
                // Create new current piece
                CurrentPiece = Piece.GetPiece(
                    (PieceType)randGen.Next(typeCount),
                    (PieceRotation)randGen.Next(rotationCount),
                    false
                );
                initPos = CurrentPiece.GetInitialPosition();
                CurrentPiece.PosX = (_display.BoardHeightInBlocks() / 2) + initPos.X;
                CurrentPiece.PosY = initPos.Y;
            }
            else
            {
                // Move nextPiece to currentPiece.
                initPos = nextPiece.GetInitialPosition();
                CurrentPiece = nextPiece;
                CurrentPiece.PosX = (_display.BoardWidthInBlocks() / 2) + initPos.X;
                CurrentPiece.PosY = initPos.Y;
            }

            nextPiece = Piece.GetPiece(
                (PieceType)randGen.Next(typeCount),
                (PieceRotation)randGen.Next(rotationCount)
            );
        }

        private void DrawPiece(Piece piece)
        {
            var pieceOrigin = PieceOriginInPixels(piece);

            for (int i = 0; i < piece.BlockCount; i++)
            {
                for (int j = 0; j < piece.BlockCount; j++)
                {
                    if (piece.GetBlock(j, i) != PieceBlock.NoBlock)
                    {
                        var blockOriginX = pieceOrigin.X + (j * _display.BlockSizeInPixels());
                        var blockOriginY = pieceOrigin.Y + (i * _display.BlockSizeInPixels());
                        _display.DrawBlock(blockOriginX, blockOriginY, piece.Color);
                    }
                }
            }
        }

        private void DrawBoard()
        {
            _display.DrawFixedAreas(_board);
        }

        public void DrawScene()
        {
            DrawBoard();
            DrawPiece(CurrentPiece);
            DrawPiece(nextPiece);
        }

        private Position PieceOriginInPixels(Piece piece)
        {
            var baseOriginInPixels = piece.IsNextPiece ? _display.BoardOriginInPixels() : _display.NextPieceOriginInPixels();

            var originX = baseOriginInPixels.X + (piece.PosX * _display.BlockSizeInPixels());
            var originY = baseOriginInPixels.Y + (piece.PosY * _display.BoardHeightInPixels());

            return new Position(originX, originY);
        }

        public void Loop()
        {
            _display.ClearScreen();
            DrawScene();
            _display.UpdateScreen();

            long firstTime = DateTime.UtcNow.Ticks;

            while (!_display.IsQuitPressed())
            {
                var buttonPressed = _display.PollButtons();

                switch (buttonPressed)
                {
                    case GameButton.Right:
                        if (_board.IsMovementPossible(CurrentPiece, CurrentPiece.PosX + 1, CurrentPiece.PosY))
                        {
                            CurrentPiece.PosX++;
                        }
                        break;

                    case GameButton.Left:
                        if (_board.IsMovementPossible(CurrentPiece, CurrentPiece.PosX - 1, CurrentPiece.PosY))
                        {
                            CurrentPiece.PosX--;
                        }
                        break;

                    case GameButton.Down:
                        if (_board.IsMovementPossible(CurrentPiece, CurrentPiece.PosX, CurrentPiece.PosY + 1))
                        {
                            CurrentPiece.PosY++;
                        }
                        break;

                    case GameButton.Drop:
                        while (_board.IsMovementPossible(CurrentPiece, CurrentPiece.PosX, CurrentPiece.PosY + 1))
                        {
                            CurrentPiece.PosY++;
                        }
                        ChangePiece(CurrentPiece, true);
                        break;

                    case GameButton.Rotate:
                        if (_board.IsMovementPossible(CurrentPiece, CurrentPiece.PosX, CurrentPiece.PosY, true))
                        {
                            var newRotation = ((int)CurrentPiece.Rotation + 1) % 4;
                            CurrentPiece.Rotation = (PieceRotation)newRotation;
                        }
                        break;
                }

                var secondTime = DateTime.UtcNow.Ticks;

                if ((secondTime - firstTime) > waitTime)
                {
                    if (_board.IsMovementPossible(CurrentPiece, CurrentPiece.PosX, CurrentPiece.PosY + 1))
                    {
                        CurrentPiece.PosY++;
                    }
                    else
                    {
                        ChangePiece(CurrentPiece, false);
                    }

                    firstTime = DateTime.UtcNow.Ticks;
                }
            }
        }

        private bool ChangePiece(Piece piece, bool isDrop)
        {
            var posY = isDrop ? piece.PosY - 1 : piece.PosY;

            _board.StorePiece(piece, piece.PosX, posY);
            _board.DeleteAllPossibleRows();
            if (_board.IsGameOver())
            {
                return true;
            }

            CreateNewPiece();

            return false;
        }
    }
}