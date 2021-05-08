using Microsoft.Xna.Framework;
using yule.ECS;

namespace yule.Engine
{
    /// <summary>
    /// Describes the position of an entity. Provides methods to change the position.
    /// </summary>
    public class Transform : Component
    {
        public Vector2 Position { get; set; }
    }
}