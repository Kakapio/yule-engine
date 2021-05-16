using Microsoft.Xna.Framework;

namespace yule.Engine
{
    /// <summary>
    /// Components derived from here will not register to DefaultSystem. Must have their own system.
    /// </summary>
    public abstract class BaseComponent
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