using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace yule.Engine
{
    public class TileMap
    {
        public int TileSize { get; private set; }
        public Tile[,] Data { get; private set; }
        private int RenderPadding = 5; //Extra tiles to render in each direction to ensure there are no gaps.

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

        public void Render(SpriteBatch spriteBatch, Rectangle visibleArea)
        {
            //The max coordinates of tiles that should be rendered. Taken from the furthest visible points on screen.
            Vector2 upperBound = new Vector2(visibleArea.Width / TileSize, visibleArea.Height / TileSize);
            
            //The min coordinates of tiles that should be rendered. Taken from the camera's position.
            Vector2 lowerBound = new Vector2(Math.Clamp(visibleArea.X / TileSize - RenderPadding, 0, Data.GetLength(0) - 1), 
                                                  Math.Clamp(visibleArea.Y / TileSize - RenderPadding, 0, Data.GetLength(1) - 1));
            
            /*Calculate a new upperBound taking into account our original value, camera's position, and padding.
             Max value is the size of our array, minimum is 0.*/
            upperBound = new Vector2(Math.Clamp(upperBound.X + lowerBound.X + RenderPadding, 0, Data.GetLength(0)),
                                     Math.Clamp(upperBound.Y + lowerBound.Y + RenderPadding, 0, Data.GetLength(1)));
            
            for (int col = (int)lowerBound.X; col < upperBound.X; col++)
            {
                for (int row = (int)lowerBound.Y; row < upperBound.Y; row++)
                {
                    if (Data[col, row].Type == TileType.Air)
                        continue;
                    
                    spriteBatch.Draw(GameContent.Textures[Data[col, row].Type.ToString().ToLower()], 
                        new Vector2(col * TileSize, row * TileSize), Color.White);
                }
            }
        }
    }
}