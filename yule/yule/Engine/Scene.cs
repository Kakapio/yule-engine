using System;
using System.Collections.Generic;
using Humper;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using yule.Gameplay;

namespace yule.Engine
{
    /// <summary>
    /// Contains all the entities used in the current scene.
    /// </summary>
    public class Scene
    {
        public readonly List<Entity> Entities = new List<Entity>();
        public TileMap TileMap = new TileMap(1024, 1024, 8);

        private World physicsWorld;
        private Camera camera;
        private bool debugMode;
        private KeyboardState prevKeyBoardState;

        public Scene(GraphicsDevice graphicsDevice)
        {
            camera = new Camera(graphicsDevice);
            physicsWorld = new World(graphicsDevice.Viewport.Bounds.X, graphicsDevice.Viewport.Bounds.Y);
        }
        
        public void Initialize()
        {
            Entities.Add(new Player());
            Entities.Add(new CollidableBox());
            foreach (var entity in Entities)
            {
                entity.Initialize();
            }
            prevKeyBoardState = Keyboard.GetState();
        }

        public void Update(GameTime gameTime)
        {
            camera.Update();
            
            TransformSystem.Update(gameTime);
            SpriteSystem.Update(gameTime);
            ColliderSystem.Update(gameTime);
            DefaultSystem.Update(gameTime);
            
            CheckDebugMode();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: camera.ViewMatrix, samplerState: SamplerState.PointClamp);
            
            TileMap.Render(spriteBatch, camera.VisibleArea, debugMode);

            //Render all entities.
            foreach (var entity in Entities)
            {
                var renderer = entity.GetComponent<Sprite>();
                
                if (renderer != null)
                {
                    renderer.Render(spriteBatch, debugMode);
                }
            }
            
            spriteBatch.End();
        }
        
        private void CheckDebugMode()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            //Make sure DebugRender can only be triggered once a frame.
            if (keyboardState.IsKeyDown(Keys.OemTilde) && !prevKeyBoardState.IsKeyDown(Keys.OemTilde))
                debugMode = !debugMode;

            prevKeyBoardState = keyboardState;
        }
    }
}