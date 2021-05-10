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
            spriteBatch.Begin(transformMatrix: camera.TransformMatrix, samplerState: SamplerState.PointClamp);
            
            TileMap.Render(spriteBatch, camera.VisibleArea, debugMode);

            //Render all entities.
            foreach (var entity in Entities)
            {
                var renderer = entity.GetComponent<Sprite>();
                var transform = entity.GetComponent<Transform>();
                
                if (renderer != null)
                {
                    if (renderer.Dimensions.IsEmpty)
                        spriteBatch.Draw(renderer.Texture, transform.Position, renderer.Color);
                    else
                        spriteBatch.Draw(renderer.Texture, new Rectangle((int)transform.Position.X, (int)transform.Position.Y,
                            renderer.Dimensions.Width, renderer.Dimensions.Height), renderer.Color);

                    //Rendering code to show colliders
                    if (debugMode)
                    {
                        if (entity.GetComponent<Collider>() != null)
                        {
                            RenderColliderOutline(spriteBatch, entity);
                        }
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
        
        private void RenderColliderOutline(SpriteBatch spriteBatch, Entity entity)
        {
            int posX = (int) entity.GetComponent<Transform>().Position.X;
            int posY = (int) entity.GetComponent<Transform>().Position.Y;
            Rectangle collider = entity.GetComponent<Collider>().Dimensions;
            
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(posX, posY,
                2, collider.Height), Color.Fuchsia); // Left
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(posX + collider.Width, posY,
                2, collider.Height), Color.Fuchsia); // Right
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(posX, posY,
                collider.Width, 2), Color.Fuchsia); // Top
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(posX, posY + collider.Height,
                collider.Width + 2, 2), Color.Fuchsia); // Bottom TODO investigate
        }
    }
}