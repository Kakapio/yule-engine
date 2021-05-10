using System.Collections.Generic;
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
        
        private Camera camera;
        private bool debugMode;
        private KeyboardState prevKeyBoardState;

        public Scene(GraphicsDevice graphicsDevice)
        {
            camera = new Camera(graphicsDevice);
        }
        
        public void Initialize()
        {
            Entities.Add(new Player());
            foreach (var entity in Entities)
            {
                entity.Initialize();
            }
            prevKeyBoardState = Keyboard.GetState();
        }

        public void Update(GameTime gameTime)
        {
            camera.Update();
            
            foreach (var entity in Entities)
            {
                entity.Update(gameTime);
            }
            
            #if DEBUG
            CheckDebugMode();
            #endif
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: camera.TransformMatrix);
            
            TileMap.Render(spriteBatch, camera.VisibleArea, debugMode);

            //Render all entities.
            foreach (var entity in Entities)
            {
                var renderer = entity.GetComponent<SpriteRenderer>();
                var transform = entity.GetComponent<Transform>();
                
                if (renderer != null)
                {
                    if (renderer.Dimensions.IsEmpty)
                        spriteBatch.Draw(renderer.Sprite, transform.Position, renderer.Color);
                    else
                        spriteBatch.Draw(renderer.Sprite, new Rectangle((int)transform.Position.X, (int)transform.Position.Y,
                            renderer.Dimensions.Width, renderer.Dimensions.Height), renderer.Color);

                    //Rendering code to show colliders
                    if (debugMode)
                    {
                        //TODO
                    }
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