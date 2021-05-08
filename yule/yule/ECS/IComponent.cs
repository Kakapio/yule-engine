using Microsoft.Xna.Framework;

namespace yule.ECS
{
    /// <summary>
    /// Describes a piece of logic with initialization and update methods.
    /// </summary>
    public interface IComponent
    {
        public void Initialize();
        public void Update(GameTime gameTime);
    }
}