using Microsoft.Xna.Framework;

namespace HorrorMaze.Core.Player;

public static class PlayerPositions
{
    private static int idCurrentPosition;

    private static readonly Vector2[] Positions =
    {
        new(5, 6),
        new(2, 3),
        new(5, 8),
        new(2, 2),
    };

    public static Vector2 NextPositions()
    {
        if (idCurrentPosition == Positions.Length)
            idCurrentPosition = 0;

        return Positions[idCurrentPosition++];
    }

    public static void GameLose() => idCurrentPosition = 0;
}