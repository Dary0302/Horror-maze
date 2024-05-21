using Microsoft.Xna.Framework;

namespace HorrorMaze.Core.Player;

public static class PlayerPositions
{
    private static int idStartPosition;

    private static readonly Vector2[] Positions =
    {
        new(5, 6),
        new(2, 3),
        new(5, 8),
        new(2, 2),
        new(2, 2),
    };

    public static Vector2 NextPositions() => idStartPosition < Positions.Length ? Positions[idStartPosition++] : Positions[idStartPosition - 1];
}