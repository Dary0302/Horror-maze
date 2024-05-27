namespace HorrorMaze.Core.Maze;

public static class Mazes
{
    public static int IdCurrentLevel { get; private set; }

    private static readonly string[][] Levels =
    {
        new[]{ 
            "####.###",
            "##   ###",
            "##  ## #",
            "##     #",
            "##  ## #",
            "##  ## #",
            "##  ####",
            "#x  ####"
        },
        new []{
            "#####",
            "#   #",
            "#   #",
            "#  x#",
            "##.##"
        },
        new[]{ 
            "###x###x###",
            "#   ###   #",
            "#  # ##   #",
            "#     #   #",
            "#  # ##x  #",
            "#  #      #",
            "#  ###x   #",
            "##.########"
        },
        new[]{ 
            "#########.#",
            "##    #   #",
            "#   # # ###",
            "# x #   ###",
            "##  #######",
            "#x ##x#####",
            "##      ###",
            "###########"
        },
        /*new[]{ 
            "###############",
            "###############",
            "###############",
            "###############",
            "###############",
            "###############",
            "###############",
            "###############"
        },*/
    };
    
    public static string[] NextLevel()
    {
        if (IdCurrentLevel == Levels.Length)
            IdCurrentLevel = 0;

        return Levels[IdCurrentLevel++];
    }

    public static int GetCountLevels() => Levels.Length;

    public static void GameLose() => IdCurrentLevel = 0;
}