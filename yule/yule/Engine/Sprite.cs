using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace yule.Engine
{
    /// <summary>
    /// Contains data used to render textures more precisely.
    /// </summary>
    public class Sprite : Component
    {
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public Rectangle Dimensions { get; set; } //Used for testing purposes.

        public Sprite()
        {
            SpriteSystem.Register(this);
        }
        
        public override void Initialize()
        {
            Texture = DefaultSprites.WhiteSquare;
            Color = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
            Texture = DefaultSprites.WhiteSquare;
        }
    }
}