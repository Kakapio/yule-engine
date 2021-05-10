using Microsoft.Xna.Framework;

namespace yule.Engine
{
    //Inspired by code from stu_pidd_cow @ https://www.gamedev.net/tutorials/_/technical/game-programming/swept-aabb-collision-detection-and-response-r3084/
    
    /// <summary>
    /// Contains collision detection logic.
    /// </summary>
    public class Collider : Component
    {
        public Rectangle Dimensions { get; private set; }
        public string CollisionLayer { get; private set; }
        
        public Collider(int width, int height)
        {
            ColliderSystem.Register(this);
            Dimensions = new Rectangle(0, 0, width, height);
        }
        
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