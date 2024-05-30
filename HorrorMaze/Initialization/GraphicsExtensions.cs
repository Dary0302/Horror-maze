using Microsoft.Xna.Framework;

namespace HorrorMaze.Initialization;

public static class GraphicsExtensions
{
    public static GraphicsDeviceManager InitializeDisplayMode(this GraphicsDeviceManager graphics)
    {
        var currentDisplayMode = graphics.GraphicsDevice.DisplayMode;
        graphics.PreferredBackBufferHeight = currentDisplayMode.Height;
        graphics.PreferredBackBufferWidth = currentDisplayMode.Width;
        graphics.IsFullScreen = true;
        return graphics;
    }
}