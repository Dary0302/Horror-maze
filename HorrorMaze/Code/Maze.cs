using Microsoft.Xna.Framework;

namespace HorrorMaze;

public class Maze
{
    public readonly MapObject[,] MazeObjects;
    public readonly Vector2 StartPlayerPosition;
    public readonly Vector2 Exit;
    
    public Maze(MapObject[,] dungeon, Vector2 initialPosition, Vector2 exit)
    {
        MazeObjects = dungeon;
        StartPlayerPosition = initialPosition;
        Exit = exit;
    }
    
    public bool InBounds(Vector2 point)
        => point is { X: >= 0, Y: >= 0 }
            && MazeObjects.GetLength(0) > point.X
            && MazeObjects.GetLength(1) > point.Y;
}