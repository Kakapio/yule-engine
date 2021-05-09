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
        private Camera camera = new Camera();
        
        public void Initialize()
        {
            Entities.Add(new Player());
            foreach (var entity in Entities)
            {
                entity.Initialize();
            }
        }

        public void Update(GameTime gameTime)
        {
            foreach (var entity in Entities)
            {
                entity.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            
            //Render TileMap.
            for (int col = 0; col < TileMap.Data.GetLength(0); col++)
            {
                for (int row = 0; row < TileMap.Data.GetLength(1); row++)
                {
                    if (TileMap.Data[col, row].Type == TileType.Air)
                        continue;
                    
                    spriteBatch.Draw(GameContent.Textures[TileMap.Data[col, row].Type.ToString().ToLower()], 
                        new Vector2(col * TileMap.TileSize, row * TileMap.TileSize), Color.White);
                }
            }

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