using Microsoft.Xna.Framework;

namespace yule.Engine
{
    /// <summary>
    /// Describe an axis-aligned rectangle for collisions.
    /// </summary>
    public struct Box
    {
        public Vector2 Position;
        public float Width, Height;
        public Vector2 Velocity;

        public Box(ref Vector2 position, float width, float height, ref Vector2 velocity)
        {
            Position = position;
            Width = width;
            Height = height;
            Velocity = velocity;
        }

        public bool Intersects(Box other)
        {
            return !(Position.X + Width < other.Position.X 
                     || Position.Y + Height < other.Position.Y 
                     || Position.X > other.Position.X + other.Width 
                     || Position.Y > other.Position.Y + other.Height);
        }
    }
}