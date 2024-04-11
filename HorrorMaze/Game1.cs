using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HorrorMaze
{

    public class Game1 : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private StateGame stateGame = StateGame.MainMenuScreen;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            graphics.IsFullScreen = true; // Изменить на true
            graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            MainMenuScreen.Background = Content.Load<Texture2D>("background");
            MainMenuScreen.Font = Content.Load<SpriteFont>("SplashFont");
            MainMenuScreen.Music = Content.Load<Song>("MusicMainMenu");
            MediaPlayer.Play(MainMenuScreen.Music);
            MediaPlayer.IsRepeating = true;
            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            switch (stateGame)
            {
                case StateGame.MainMenuScreen:
                    if (keyboardState.IsKeyDown(Keys.E))
                        stateGame = StateGame.Game;
                    break;
                case StateGame.Game:
                    if (keyboardState.IsKeyDown(Keys.Enter))
                        stateGame = StateGame.MainMenuScreen;
                    break;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();

            switch (stateGame)
            {
                case StateGame.MainMenuScreen:
                    MainMenuScreen.Draw(spriteBatch);
                    break;
                case StateGame.Game:
                    MediaPlayer.Pause();
                    break;
            }
            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
