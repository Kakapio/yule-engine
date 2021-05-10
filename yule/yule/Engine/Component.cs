using Microsoft.Xna.Framework;

namespace yule.Engine
{
    /// <summary>
    /// Describes a piece of logic with initialization and update methods.
    /// </summary>
    public class Component
    {
        public Entity Owner { get; set; }

        public virtual void Initialize()
        {
        }

        public virtual void Update(GameTime gameTime)
        {
        }
    }
}