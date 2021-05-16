using yule.Engine;

namespace yule.Gameplay
{
    public class BasicMap : Entity
    {
        private TileMap tileMap = new TileMap(1024, 1024, 8);

        public override void Initialize()
        {
            base.Initialize();
            
            AddComponent(tileMap);
            
            for (int col = 16; col < tileMap.Data.GetLength(0); col++)
            for (int row = 16; row < tileMap.Data.GetLength(1); row++)
                tileMap.SetTile(col, row, new Tile(TileType.Dirt, 1));
        }
    }
}