namespace TetrisEngine
{
    public interface IDisplay
    {
        int BoardWidthInBlocks();

        int BoardHeightInBlocks();

        Position BoardOriginInPixels();

        int BlockSizeInPixels();

        int BoardWidthInPixels();

        int BoardHeightInPixels();

        void DrawBlock(int x, int y, ColorRGB color);

        void DrawRectangle(int x0, int y0, int x1, int y1, int color, bool fill = true);

        void DrawFixedAreas(Board board);

        void ClearScreen();

        void UpdateScreen();

        Position NextPieceOriginInPixels();

        bool IsQuitPressed();

        GameButton PollButtons();
    }
}