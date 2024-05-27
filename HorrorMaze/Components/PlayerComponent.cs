using HorrorMaze.Core;
using HorrorMaze.Core.Player;
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
    private Vector2 previousState;
    private Vector2 currentState;
    private Vector2 differenceState;

    public PlayerComponent(Game game) : base(game) { }

    protected override void LoadContent()
    {
        cellSize = (float)GraphicsDevice.DisplayMode.Height / 10;
        spriteBatch = new(GraphicsDevice);
        playerTexture = Game.Content.Load<Texture2D>("player");
        Game.IsFixedTimeStep = false;
        var player = Game.Services.GetService<Player>();
        previousState = player.Position;
        currentState = player.Position;
    }

    public override void Draw(GameTime gameTime)
    {
        if (HorrorMazeGame.StateGame != StateGame.Game || Player.IsMoving)
            return;

        var player = Game.Services.GetService<Player>();
        spriteBatch.Begin();
        spriteBatch.Draw(playerTexture,
            new(player.Position.X * cellSize + cellSize * 0.1f, player.Position.Y * cellSize),
            null,
            Color.White,
            0f,
            Vector2.Zero,
            cellSize / playerTexture.Height,
            SpriteEffects.None,
            0f);
        spriteBatch.End();
    }

    private void CustomDraw()
    {
        differenceState *= 0.000008f;
        while (previousState.X < currentState.X || previousState.Y < currentState.Y)
        {
            previousState += differenceState;

            spriteBatch.Begin();
            spriteBatch.Draw(playerTexture,
                new(previousState.X * cellSize + cellSize * 0.1f, previousState.Y * cellSize),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                cellSize / playerTexture.Height,
                SpriteEffects.None,
                0f);
            spriteBatch.End();
        }
        Player.IsMoving = false;
    }
    
    private void CustomDraw2()
    {
        differenceState *= 0.000008f;
        while (previousState.X > currentState.X || previousState.Y > currentState.Y)
        {
            previousState += differenceState;

            spriteBatch.Begin();
            spriteBatch.Draw(playerTexture,
                new(previousState.X * cellSize + cellSize * 0.1f, previousState.Y * cellSize),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                cellSize / playerTexture.Height,
                SpriteEffects.None,
                0f);
            spriteBatch.End();
        }
        Player.IsMoving = false;
    }

    public override void Update(GameTime gameTime)
    {
        if (Player.IsMoving)
            return;
        
        var keyboardState = Keyboard.GetState();
        if (keyboardState.IsKeyDown(Keys.W))
        {
            MoveToDirection(MoveDirection.Up);
            CustomDraw2();
        }
        else if (keyboardState.IsKeyDown(Keys.S))
        {
            MoveToDirection(MoveDirection.Down);
            CustomDraw();
        }
        else if (keyboardState.IsKeyDown(Keys.A))
        {
            MoveToDirection(MoveDirection.Left);
            CustomDraw2();
        }
        else if (keyboardState.IsKeyDown(Keys.D))
        {
            MoveToDirection(MoveDirection.Right);
            CustomDraw();
        }
    }

    private void MoveToDirection(Vector2 newPosition)
    {
        var player = Game.Services.GetService<Player>();
        var simpleGameService = Game.Services.GetService<SimpleGameService>();
        previousState = player.Position;
        simpleGameService.Move(newPosition);
        currentState = player.Position;
        differenceState = currentState - previousState;
        Player.IsMoving = true;
    }
}