using Microsoft.Xna.Framework;

namespace HorrorMaze.Core.Services;

public class SimpleGameService
{
    private readonly Maze.Maze maze;
    private readonly Player.Player player;

    public SimpleGameService(Maze.Maze maze, Player.Player player)
    {
        this.maze = maze;
        this.player = player;
    }

    public void Move(Vector2 position)
    {
        if (!maze.ObjectInBounds(player.Position + position))
            return;
        
        player.Move(position);
        maze.ObjectOnPortal(player.Position);
        maze.ObjectOnTrapHatch(player.Position);
    }
}