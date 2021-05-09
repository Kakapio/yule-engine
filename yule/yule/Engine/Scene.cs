using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yule.ECS;
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
            Entities[0].GetComponent<Transform>().Position = new Vector2(-640, -360);
        }

        public void Update(GameTime gameTime)
        {
            camera.UpdateCamera();
            
            foreach (var entity in Entities)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(transformMatrix: camera.Transform);
            
            TileMap.Render(spriteBatch, camera.VisibleArea);

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
                }
            }
            
            spriteBatch.End();
        }
    }
}