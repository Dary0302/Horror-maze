﻿using HorrorMaze.Components;
using HorrorMaze.Core.Maze;
using HorrorMaze.Core.Player;
using HorrorMaze.Core.Services;
using HorrorMaze.Core.Terrains;
using HorrorMaze.Initialization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace HorrorMaze
{
    public class HorrorMazeGame : Game
    {
        private readonly GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        public static StateGame StateGame = StateGame.MainMenuScreen;

        public HorrorMazeGame()
        {
            graphics = new(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Services.AddService(new Maze(Mazes.FirstMaze));
            Services.AddService(new Player(new(200, 200)));
            Services.AddService(new SimpleGameService(Services.GetService<Maze>(), Services.GetService<Player>()));
            Components.Add(new MainMenuComponent(this));
            Components.Add(new MapComponent(this));
            Components.Add(new PlayerComponent(this));
        }

        protected override void Initialize()
        {
            graphics.InitializeDisplayMode().ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new(GraphicsDevice);
            MediaPlayer.IsRepeating = true;
        }

        protected override void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            switch (StateGame)
            {
                case StateGame.MainMenuScreen:
                    if (keyboardState.IsKeyDown(Keys.E))
                        StateGame = StateGame.Game;
                    break;
                case StateGame.Game:
                    if (keyboardState.IsKeyDown(Keys.Enter))
                        StateGame = StateGame.MainMenuScreen;
                    break;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}