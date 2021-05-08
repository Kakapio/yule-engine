using yule.ECS;
using yule.Engine;

namespace yule.Gameplay
{
    public class Player : Entity
    {
        private SpriteRenderer renderer = new SpriteRenderer();
        
        public override void Initialize()
        {
            base.Initialize();
            
            AddComponent(renderer);
        }
    }
}