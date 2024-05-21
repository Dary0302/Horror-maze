using HorrorMaze.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HorrorMaze.Components;

public class MainMenuComponent : DrawableGameComponent
{
    private Texture2D background;
    private SpriteBatch spriteBatch;
    private SpriteFont font;
    private static readonly Vector2 TextPosition = new(500, 900);
    private Song music;

    public MainMenuComponent(Game game) : base(game) { }
    
    protected override void LoadContent()
    {
        spriteBatch = new(GraphicsDevice);
        font = Game.Content.Load<SpriteFont>("SplashFont");
        background = Game.Content.Load<Texture2D>("backGround");
        music = Game.Content.Load<Song>("MusicMainMenu");
        MediaPlayer.Play(music);
    }

    public override void Draw(GameTime gameTime)
    {
        if (HorrorMazeGame.StateGame != StateGame.MainMenuScreen)
            return;
        spriteBatch.Begin();
        spriteBatch.Draw(background, new Rectangle(0, 0, 1920, 1800), Color.White);
        spriteBatch.DrawString(font, "Нажмите E для продолжения!", TextPosition, Color.White);
        spriteBatch.End();
    }

    public override void Update(GameTime gameTime)
    {
        var keyboardState = Keyboard.GetState();

        if (!keyboardState.IsKeyDown(Keys.E))
            return;
        
        MediaPlayer.Stop();
        HorrorMazeGame.StateGame = StateGame.Game;
    }
}