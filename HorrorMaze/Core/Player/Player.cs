using Microsoft.Xna.Framework;

namespace HorrorMaze.Core.Player;

public class Player : IPlayer
{
    public Vector2 Position { get; set; }
    public readonly float Speed = 1;
    public readonly float Hp = 1000;
    public static bool IsMoving;

    //private bool IsDead => Hp <= 0 ? true : false;

    public Player(Vector2 position)
    {
        Position = position;
        IsMoving = false;
    }

    public void Move(Vector2 target)
    {
        if (IsMoving)
            return;
        Position += target;
    } 
}