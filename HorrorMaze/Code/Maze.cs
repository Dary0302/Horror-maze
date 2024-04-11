namespace HorrorMaze;

public class Maze
{
    public readonly MapObject[,] MazeObjects;
    public readonly Point StartPlayerPosition;
    public readonly Point Exit;
    
    public Maze(MapObject[,] dungeon, Point initialPosition, Point exit)
    {
        MazeObjects = dungeon;
        StartPlayerPosition = initialPosition;
        Exit = exit;
    }
    
    public bool InBounds(Point point)
        => point is { X: >= 0, Y: >= 0 }
            && MazeObjects.GetLength(0) > point.X
            && MazeObjects.GetLength(1) > point.Y;
}