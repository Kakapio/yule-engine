using Microsoft.Xna.Framework;

namespace yule.Engine
{
    //Inspired by code from stu_pidd_cow @ https://www.gamedev.net/tutorials/_/technical/game-programming/swept-aabb-collision-detection-and-response-r3084/
    
    /// <summary>
    /// Contains collision detection logic.
    /// </summary>
    public class Collider : Component
    {
        public Box Dimensions { get; private set; }
        public string CollisionLayer { get; private set; }

        private int width, height;
        
        public Collider(int width, int height)
        {
            ColliderSystem.Register(this);
            this.width = width;
            this.height = height;
        }
        
        public override void Initialize()
        {
            base.Initialize();
            
            Dimensions = new Box(ref Owner.GetComponent<Transform>().Position, width, height, 
                ref Owner.GetComponent<Transform>().Velocity);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}