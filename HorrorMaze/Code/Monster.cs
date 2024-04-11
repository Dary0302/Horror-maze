using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace HorrorMaze;

public class Monster
{
    public Vector2 CurrentPosition;
    public readonly Maze Maze;
    public readonly float Speed = 50;

    public Monster(Maze maze)
    {
        Maze = maze;
        CurrentPosition = Maze.StartPlayerPosition;
    }

    public void MoveMonster(KeyboardState keyboardState)
    {
        if (false)
        {
            TryMoveMonster(MoveDirection.Up);
        }
        else if (false)
        {
            TryMoveMonster(MoveDirection.Down);
        }
        else if (false)
        {
            TryMoveMonster(MoveDirection.Left);
        }
        else if (false)
        {
            TryMoveMonster(MoveDirection.Right);
        }
    }
    
    private void TryMoveMonster(Vector2 direction)
    {
        var tempPosition = CurrentPosition + direction;
        if (Maze.InBounds(tempPosition) && Maze.MazeObjects[(int)tempPosition.X, (int)tempPosition.Y] != MapObject.Wall)
            CurrentPosition = tempPosition;
    }
}