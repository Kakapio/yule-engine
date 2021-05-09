namespace yule.Engine
{
    public enum TileType
    {
        Air = 0,
        Dirt
    }
    
    public struct Tile
    {
        public TileType Type;
        public int HitsLeft; //Hits until tile is destroyed.
        
        public Tile(TileType type, int hitsLeft)
        {
            Type = type;
            HitsLeft = hitsLeft;
        }
    }
}