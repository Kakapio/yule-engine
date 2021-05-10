using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace yule.Engine
{
    /// <summary>
    /// Contain default sprites for placeholder use.
    /// </summary>
    public static class DefaultSprites
    {
        public static Texture2D WhiteSquare { get; private set; }
        
        public static void Load(GraphicsDevice graphicsDevice)
        {
            WhiteSquare = new Texture2D(graphicsDevice, 1, 1);
            WhiteSquare.SetData(new[] { Color.White });
        }
    }
}