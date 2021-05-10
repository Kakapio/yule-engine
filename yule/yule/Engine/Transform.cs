using Microsoft.Xna.Framework;

namespace yule.Engine
{
    /// <summary>
    /// Describes the position of an entity. Provides methods to change the position.
    /// </summary>
    public class Transform : Component
    {
        public Vector2 Position { get; private set; }
        public Vector2 Velocity { get; private set; }

        public Transform()
        {
            TransformSystem.Register(this);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            Position += Velocity;
            Velocity = Vector2.Zero;
        }

        public void Translate(Vector2 amount)
        {
            Velocity += amount;
        }
    }
}