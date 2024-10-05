public static class MazeConfig
{
    private static int _mazeWidth = 41;
    private static int _mazeHeight = 41;
    public static int MazeWidth
    {
        private set { _mazeWidth = value; }
        get => _mazeWidth;
    }

    public static int MazeHeight
    {
        private set { _mazeHeight = value; }
        get => _mazeHeight;
    }

    public static void SetSize((int Width, int Height) size)
    {
        MazeWidth = size.Width;
        MazeHeight = size.Height;
    }
}
