using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace HorrorMaze;

public class Player
{
    public Vector2 CurrentPosition;
    public readonly Maze Maze;
    public readonly float Speed = 100;
    public readonly float Hp = 1000;

    private bool IsDead => Hp <= 0 ? true : false;
    
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

    private void TryMovePlayer(Vector2 direction)
    {
        var tempPosition = CurrentPosition + direction;
        if (Maze.InBounds(tempPosition) && Maze.MazeObjects[(int)tempPosition.X, (int)tempPosition.Y] != MapObject.Wall)
            CurrentPosition = tempPosition;
    }
    
}