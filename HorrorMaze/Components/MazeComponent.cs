using System.Linq;
using HorrorMaze.Core.Maze;
using HorrorMaze.Core.Terrains;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace HorrorMaze.Components;

public class MapComponent : DrawableGameComponent
{
    private SpriteBatch spriteBatch;
    private Texture2D grassTexture;
    private Texture2D portalTexture;
    private float cellSize;

    public MapComponent(Game game) : base(game)
    {
    }

    protected override void LoadContent()
    {
        spriteBatch = new(GraphicsDevice);
        grassTexture = Game.Content.Load<Texture2D>("floor");
        portalTexture = Game.Content.Load<Texture2D>("portal");
        cellSize = (float)GraphicsDevice.DisplayMode.Height / 10;
    }

    public override void Draw(GameTime gameTime)
    {
        if (HorrorMazeGame.StateGame != StateGame.Game)
            return;
        var map = Game.Services.GetService<Maze>();
        spriteBatch.Begin();
        foreach (var i in Enumerable.Range(0, map.MapObjects.Length))
        {
            foreach (var j in Enumerable.Range(0, map.MapObjects.Length))
            {
                var terrain = map.Terrains[i][j];
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
                            cellSize / grassTexture.Width,
                            SpriteEffects.None,
                            0f);
                        break;
                }
            }
        }
        spriteBatch.End();
    }
}