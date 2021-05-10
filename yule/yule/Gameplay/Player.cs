using Microsoft.Xna.Framework;
using yule.Engine;

namespace yule.Gameplay
{
    public class Player : Entity
    {
        private Sprite renderer = new Sprite();
        
        public override void Initialize()
        {
            base.Initialize();
            
            AddComponent(renderer);
            AddComponent(new PlayerMovement());
            renderer.Dimensions = new Rectangle(0, 0, 25, 25);
            renderer.Color = Color.Red;
        }
    }
}