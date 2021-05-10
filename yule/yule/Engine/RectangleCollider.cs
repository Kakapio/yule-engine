using Microsoft.Xna.Framework;

namespace yule.Engine
{
    public class RectangleCollider : Component
    {
        public string CollisionLayer { get; private set; }
        
        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}