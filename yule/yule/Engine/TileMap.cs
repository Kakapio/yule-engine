namespace yule.Engine
{
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
    }
}