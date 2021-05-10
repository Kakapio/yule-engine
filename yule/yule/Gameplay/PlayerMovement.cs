using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using yule.Engine;

namespace yule.Gameplay
{
    public class PlayerMovement : Component
    {
        private Vector2 speed = Vector2.One * 1500;
        private Transform transform;

        public override void Initialize()
        {
            base.Initialize();

            transform = Owner.GetComponent<Transform>();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            float deltaTime = (float) gameTime.ElapsedGameTime.TotalSeconds;

            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.A))
                transform.Position -= new Vector2(speed.X, 0) * deltaTime;
            else if (state.IsKeyDown(Keys.D))
                transform.Position += new Vector2(speed.X, 0) * deltaTime;
            if (state.IsKeyDown(Keys.S))
                transform.Position += new Vector2(0, speed.Y) * deltaTime;
            else if (state.IsKeyDown(Keys.W))
                transform.Position -= new Vector2(0, speed.Y) * deltaTime;
        }
    }
}