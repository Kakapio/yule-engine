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
        public float Width { get; private set; }
        public float Height { get; private set; }
        
        public Collider(float width, float height)
        {
            ColliderSystem.Register(this);
            Width = width;
            Height = height;
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