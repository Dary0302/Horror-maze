using System.Linq;
using HorrorMaze.Core.Terrains;
using Microsoft.Xna.Framework;

namespace HorrorMaze.Core.Maze;

public class Maze
{
    public readonly ITerrain[][] Terrains;
    public readonly string[] MapObjects;

    public Maze(string[] mapObjects)
    {
        MapObjects = mapObjects;
        Terrains = new ITerrain[MapObjects.Length][];
        foreach (var i in Enumerable.Range(0, MapObjects.Length))
        {
            Terrains[i] = new ITerrain[MapObjects.Length];
            foreach (var j in Enumerable.Range(0, MapObjects[0].Length))
            {
                Terrains[i][j] = MapObjects[i][j] switch
                {
                    ' ' => new Floor(),
                    '.' => new Portal(),
                    var _ => Terrains[i][j]
                };
            }
        }
    }

    public bool ObjectInBounds(Vector2 point)
        => point is { X: >= 0, Y: >= 0 }
        && point.X <= Terrains[0].Length * 100
        && point.Y <= Terrains.Length * 100
        && Terrains[(int)point.X / 100][(int)point.Y / 100] is Floor or Portal;

    public ITerrain GetTerrain(Vector2 position)
    {
        return Terrains[(int)position.X][(int)position.Y];
    }
}