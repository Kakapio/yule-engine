﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using yule.ECS;
using yule.Engine;

namespace yule.Gameplay
{
    public class PlayerMovement : Component
    {
        private Vector2 speed = Vector2.One * 75;
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
            if (state.IsKeyDown(Keys.D))
                transform.Position += new Vector2(speed.X, 0) * deltaTime;
        }
    }
}