using Microsoft.Xna.Framework;

namespace HorrorMaze.Core.Player;

public static class MoveDirection
{
    public static readonly Vector2 Up = new(0, -1);
    public static readonly Vector2 Down = new(0, 1);
    public static readonly Vector2 Left = new(-1, 0);
    public static readonly Vector2 Right = new(1, 0);
}