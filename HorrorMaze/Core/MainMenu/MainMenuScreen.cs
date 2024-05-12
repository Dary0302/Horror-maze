/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace HorrorMaze
{
    public static class MainMenuScreen
    {
        public static Texture2D Background { get; set; }
        public static SpriteFont Font { get; set; }
        public static Song Music { get; set; }
        private static readonly Vector2 TextPosition = new(500, 900);

        public static void Draw(SpriteBatch spriteBatch)
        {
            MediaPlayer.Resume();
            spriteBatch.Draw(Background, new Rectangle(0, 0, 1920, 1800), Color.White);
            spriteBatch.DrawString(Font, "Нажмите E для продолжения!", TextPosition, Color.White);
        }
    }
}*/