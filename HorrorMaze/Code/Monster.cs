using Microsoft.Xna.Framework.Input;

namespace HorrorMaze;

public class Monster
{
    public Point CurrentPosition;
    public readonly Maze Maze;

    public Monster(Maze maze)
    {
        Maze = maze;
        CurrentPosition = Maze.StartPlayerPosition;
    }

    public void MovePlayer(KeyboardState keyboardState)
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
    
    private void TryMoveMonster(Point direction)
    {
        var tempPosition = CurrentPosition + direction;
        if (Maze.InBounds(tempPosition) && Maze.MazeObjects[tempPosition.X, tempPosition.Y] != MapObject.Wall)
            CurrentPosition = tempPosition;
    }
}