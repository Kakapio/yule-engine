using Microsoft.Xna.Framework;

namespace yule.Engine
{
    /// <summary>
    /// Describes the position of an entity. Provides methods to change the position.
    /// </summary>
    public class Transform : Component
    {
        public Vector2 Position;
        public Vector2 Velocity;
        public bool Colliding;

        private Vector2 prevPosition;

        public Transform()
        {
            TransformSystem.Register(this);
        }

        public override void Initialize()
        {
            base.Initialize();

            prevPosition = Position;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            //if (!Colliding)
            //{
                Position += Velocity;
                Velocity = Vector2.Zero;
            //}

            prevPosition = Position;
        }

        public void Translate(Vector2 amount)
        {
            Velocity += amount;
        }
    }
}