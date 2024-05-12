
using Microsoft.Xna.Framework;

namespace HorrorMaze.Core.Services;

public class SimpleGameService
{
    public readonly Maze.Maze Maze;
    public readonly Player.Player Player;

    public SimpleGameService(Maze.Maze maze, Player.Player player)
    {
        this.Maze = maze;
        this.Player = player;
    }

    public void Move(Vector2 position)
    {
        if (Maze.ObjectInBounds(Player.Position + position))
            Player.Move(position);
    }
}