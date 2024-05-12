using Microsoft.Xna.Framework;

namespace HorrorMaze.Core.Player;

public class Player : IPlayer
{
    public Vector2 Position { get; set; }
    public readonly float Speed = 10;
    public readonly float Hp = 1000;

    private bool IsDead => Hp <= 0 ? true : false;

    public Player(Vector2 position) => Position = position;

    public void Move(Vector2 target) => Position += target * Speed;
}