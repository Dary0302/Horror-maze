using System.Linq;
using HorrorMaze.Components;
using HorrorMaze.Core.Player;
using HorrorMaze.Core.Terrains;
using Microsoft.Xna.Framework;

namespace HorrorMaze.Core.Maze;

public class Maze
{
    public readonly ITerrain[][] Terrains;
    public readonly string[] MapObjects;
    public MazeStatus Status;
    private readonly Vector2 portalPosition;

    public Maze(string[] mapObjects)
    {
        MapObjects = mapObjects;
        Terrains = new ITerrain[MapObjects.Length][];
        foreach (var i in Enumerable.Range(0, MapObjects.Length))
        {
            Terrains[i] = new ITerrain[MapObjects[0].Length];
            foreach (var j in Enumerable.Range(0, MapObjects[0].Length))
            {
                switch (MapObjects[i][j])
                {
                    case ' ':
                        Terrains[i][j] = new Floor();
                        break;
                    case '.':
                        Terrains[i][j] = new Portal();
                        portalPosition = new(i, j);
                        break;
                    case 'x':
                        Terrains[i][j] = new TrapHatch();
                        break;
                    case var _:
                        Terrains[i][j] = Terrains[i][j];
                        break;
                }
            }
        }
    }

    public bool ObjectInBounds(Vector2 point)
        => point is { X: >= 0, Y: >= 0 }
            && point.X < Terrains.Length
            && point.Y < Terrains[0].Length
            && Terrains[(int)point.X][(int)point.Y] is Floor or Portal or TrapHatch;

    public void ObjectOnPortal(Vector2 point)
    {
        if (portalPosition != point)
            return;

        Status = MazeStatus.Completed;
        MazeComponent.IsGameStateChanged = true;
    }

    public void ObjectOnTrapHatch(Vector2 point)
    {
        if (Terrains[(int)point.X][(int)point.Y] is not TrapHatch && Mazes.IdCurrentLevel != Mazes.GetCountLevels() + 1)
            return;

        Mazes.GameLose();
        PlayerPositions.GameLose();
        Status = MazeStatus.Loosed;
        MazeComponent.IsGameStateChanged = true;
    }
}