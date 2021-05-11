using Microsoft.Xna.Framework;
using yule.Engine;

namespace yule.Gameplay
{
    public class CollidableBox : Entity
    {
        private Sprite renderer = new Sprite();
        private Collider collider = new Collider(64, 64);
        
        public override void Initialize()
        {
            base.Initialize();
            
            AddComponent(renderer);
            AddComponent(collider);
            renderer.Dimensions = new Rectangle(0, 0, 64, 64);
            GetComponent<Transform>().Position = new Vector2(-128, -128);
        }
    }
}