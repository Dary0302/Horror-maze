using HorrorMaze.Core.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HorrorMaze.Components;

public class PlayerComponent : DrawableGameComponent
{
    private Texture2D playerTexture;
    private SpriteBatch spriteBatch;
    private float cellSize;

    public PlayerComponent(Game game) : base(game) { }

    protected override void LoadContent()
    {
        cellSize = (float)GraphicsDevice.DisplayMode.Height / 10;
        spriteBatch = new(GraphicsDevice);
        playerTexture = Game.Content.Load<Texture2D>("player");
    }

    public override void Draw(GameTime gameTime)
    {
        if (HorrorMazeGame.StateGame != StateGame.Game)
            return;
        var player = Game.Services.GetService<Core.Player.Player>();
        spriteBatch.Begin();
        spriteBatch.Draw(playerTexture,
            new(player.Position.X, player.Position.Y),
            null,
            Color.White,
            0f,
            Vector2.Zero,
            cellSize / playerTexture.Width,
            SpriteEffects.None,
            0f);
        spriteBatch.End();
    }

    public override void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.W))
            MoveToDirection(MoveDirection.Up);
        else if (keyboardState.IsKeyDown(Keys.S))
            MoveToDirection(MoveDirection.Down);
        else if (keyboardState.IsKeyDown(Keys.A))
            MoveToDirection(MoveDirection.Left);
        else if (keyboardState.IsKeyDown(Keys.D))
            MoveToDirection(MoveDirection.Right);
    }

    private void MoveToDirection(Vector2 newPosition)
    {
        var simpleGameService = Game.Services.GetService<SimpleGameService>();
        simpleGameService.Move(newPosition);
    }
}