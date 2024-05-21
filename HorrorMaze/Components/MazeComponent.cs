using System.Linq;
using HorrorMaze.Core;
using HorrorMaze.Core.Maze;
using HorrorMaze.Core.Player;
using HorrorMaze.Core.Services;
using HorrorMaze.Core.Terrains;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HorrorMaze.Components;

public class MazeComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private Texture2D grassTexture;
    private Texture2D portalTexture;
    private Texture2D trapHatchTexture;
    private float cellSize;

    public MazeComponent(Game game) : base(game)
    {
    }

    protected override void LoadContent()
    {
        spriteBatch = new(GraphicsDevice);
        grassTexture = Game.Content.Load<Texture2D>("floor");
        portalTexture = Game.Content.Load<Texture2D>("portal");
        trapHatchTexture = Game.Content.Load<Texture2D>("TrapHatch");
        cellSize = (float)GraphicsDevice.DisplayMode.Height / 10;
    }

    public override void Draw(GameTime gameTime)
    {
        if (HorrorMazeGame.StateGame != StateGame.Game)
            return;
        
        var maze = Game.Services.GetService<Maze>();
        
        switch (maze.Status)
        {
            case MazeStatus.Completed:
                Game.Services.RemoveService(typeof(SimpleGameService));
                Game.Services.RemoveService(typeof(Maze));
                Game.Services.RemoveService(typeof(Player));
                Game.Services.AddService(new Maze(Mazes.NextLevel()));
                Game.Services.AddService(new Player(PlayerPositions.NextPositions()));
                Game.Services.AddService(new SimpleGameService(Game.Services.GetService<Maze>(), Game.Services.GetService<Player>()));
                maze = Game.Services.GetService<Maze>();
                break;
            case MazeStatus.Loosed:
                Game.Services.RemoveService(typeof(SimpleGameService));
                Game.Services.RemoveService(typeof(Maze));
                Game.Services.RemoveService(typeof(Player));
                HorrorMazeGame.StateGame = StateGame.MainMenuScreen;
                break;
        }
        
        spriteBatch.Begin();
        foreach (var i in Enumerable.Range(0, maze.MapObjects.Length))
        {
            foreach (var j in Enumerable.Range(0, maze.MapObjects[0].Length))
            {
                var terrain = maze.Terrains[i][j];
                switch (terrain)
                {
                    case Floor:
                        spriteBatch.Draw(grassTexture,
                            new(i * cellSize, j * cellSize),
                            null,
                            Color.White,
                            0f,
                            Vector2.Zero,
                            cellSize / grassTexture.Width,
                            SpriteEffects.None,
                            0f);
                        break;
                    case Portal:
                        spriteBatch.Draw(grassTexture,
                            new(i * cellSize, j * cellSize),
                            null,
                            Color.White,
                            0f,
                            Vector2.Zero,
                            cellSize / grassTexture.Width,
                            SpriteEffects.None,
                            0f);
                        spriteBatch.Draw(portalTexture,
                            new(i * cellSize, j * cellSize),
                            null,
                            Color.White,
                            0f,
                            Vector2.Zero,
                            cellSize / portalTexture.Width,
                            SpriteEffects.None,
                            0f);
                        break;
                    case TrapHatch:
                        spriteBatch.Draw(grassTexture,
                            new(i * cellSize, j * cellSize),
                            null,
                            Color.White,
                            0f,
                            Vector2.Zero,
                            cellSize / grassTexture.Width,
                            SpriteEffects.None,
                            0f);
                        spriteBatch.Draw(trapHatchTexture,
                            new(i * cellSize, j * cellSize),
                            null,
                            Color.White,
                            0f,
                            Vector2.Zero,
                            cellSize / trapHatchTexture.Width,
                            SpriteEffects.None,
                            0f);
                        break;
                }
            }
        }
        spriteBatch.End();
    }
}