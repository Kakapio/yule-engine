using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace yule.Engine
{
    /// <summary>
    /// Represents a 2D array of tiles.
    /// </summary>
    public class TileMap
    {
        public int TileSize { get; private set; }
        public Tile[,] Data { get; private set; }

        public TileMap(int sizeX, int sizeY, int tileSize)
        {
            Data = new Tile[sizeX, sizeY];
            TileSize = tileSize;
            
            //Initialize all tiles to air
            for (int col = 0; col < Data.GetLength(0); col++)
            for (int row = 0; row < Data.GetLength(1); row++)
                Data[col, row] = new Tile(TileType.Air, 1);
            
            for (int col = 16; col < Data.GetLength(0); col++)
            for (int row = 16; row < Data.GetLength(1); row++)
                Data[col, row] = new Tile(TileType.Dirt, 1);
        }

        public void Render(SpriteBatch spriteBatch, Rectangle visibleArea, bool debugMode)
        {
            //The max coordinates of tiles that should be rendered. Taken from the furthest visible points on screen.
            Vector2 upperBound = new Vector2(visibleArea.Width / TileSize, visibleArea.Height / TileSize);
            
            //The min coordinates of tiles that should be rendered. Taken from the camera's position.
            Vector2 lowerBound = new Vector2(Math.Clamp(visibleArea.X / TileSize, 0, Data.GetLength(0) - 1), 
                Math.Clamp(visibleArea.Y / TileSize, 0, Data.GetLength(1) - 1));
            
            /*Calculate a new upperBound taking into account our original value, camera's position, and padding.
             Max value is the size of our array, minimum is 0.*/
            upperBound = new Vector2(Math.Clamp(upperBound.X + lowerBound.X, 0, Data.GetLength(0) - 1),
                Math.Clamp(upperBound.Y + lowerBound.Y, 0, Data.GetLength(1) - 1));
            
            //Draw loop is constrained to visible tiles. Anything done within will also have culling built-in.
            for (int col = (int)lowerBound.X; col <= upperBound.X; col++)
            {
                for (int row = (int)lowerBound.Y; row <= upperBound.Y; row++)
                {
                    if (Data[col, row].Type == TileType.Air && !debugMode)
                        continue;
                    
                    //Render air tile outline in debug mode.
                    if (Data[col, row].Type == TileType.Air && debugMode)
                    {
                        RenderTileOutline(spriteBatch, col, row);
                        continue;
                    }
                    
                    spriteBatch.Draw(GameContent.Textures[Data[col, row].Type.ToString().ToLower()], 
                        new Vector2(col * TileSize, row * TileSize), Color.White);

                    if (debugMode)
                    {
                        RenderTileOutline(spriteBatch, col, row);
                    }
                }
            }
        }

        /// <summary>
        /// Render a tile's full outline. For use with first/last tiles.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="col"></param>
        /// <param name="row"></param>
        private void RenderTileOutline(SpriteBatch spriteBatch, int col, int row)
        {
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(col * TileSize, row * TileSize,
                1, TileSize), Color.Blue); // Left
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(col * TileSize, row * TileSize,
                1, TileSize), Color.Blue); // Right
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(col * TileSize, row * TileSize,
                TileSize, 1), Color.Blue); // Top
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(col * TileSize, row * TileSize,
                TileSize, 1), Color.Blue); // Bottom
        }
    }
}