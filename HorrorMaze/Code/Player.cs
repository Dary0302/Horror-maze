using Microsoft.Xna.Framework.Input;

namespace HorrorMaze;

public class Player
{
    public Point CurrentPosition;
    public readonly Maze Maze;

    public Player(Maze maze)
    {
        Maze = maze;
        CurrentPosition = Maze.StartPlayerPosition;
    }

    public void MovePlayer(KeyboardState keyboardState)
    {
        if (keyboardState.IsKeyDown(Keys.W) || keyboardState.IsKeyDown(Keys.Up))
        {
            TryMovePlayer(MoveDirection.Up);
        }
        else if (keyboardState.IsKeyDown(Keys.S) || keyboardState.IsKeyDown(Keys.Down))
        {
            TryMovePlayer(MoveDirection.Down);
        }
        else if (keyboardState.IsKeyDown(Keys.A) || keyboardState.IsKeyDown(Keys.Left))
        {
            TryMovePlayer(MoveDirection.Left);
        }
        else if (keyboardState.IsKeyDown(Keys.D) || keyboardState.IsKeyDown(Keys.Right))
        {
            TryMovePlayer(MoveDirection.Right);
        }
    }

    private void TryMovePlayer(Point direction)
    {
        var tempPosition = CurrentPosition + direction;
        if (Maze.InBounds(tempPosition) && Maze.MazeObjects[tempPosition.X, tempPosition.Y] != MapObject.Wall)
            CurrentPosition = tempPosition;
    }
}