using Microsoft.Xna.Framework;
using yule.ECS;

namespace yule.Engine
{
    /// <summary>
    /// Describes the position of an entity. Provides methods to change the position.
    /// </summary>
    public class Transform : IComponent
    {
        public Vector2 Position { get; set; }

        public void Initialize()
        {
            Position = Vector2.Zero;
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}