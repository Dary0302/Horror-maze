namespace HorrorMaze.Core.Maze;

public static class Mazes
{
    private static int idStartLevel;

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
            "#############.#",
            "###      ##   #",
            "##   ### ## ###",
            "## x ###    ###",
            "###  ##########",
            "##x ####x######",
            "###        ###",
            "###############"
        },
        new[]{ 
            "###############",
            "###############",
            "###############",
            "###############",
            "###############",
            "###############",
            "###############",
            "###############"
        },
    };

    public static string[] NextLevel() => idStartLevel < Levels.Length ? Levels[idStartLevel++] : Levels[idStartLevel - 1];
}