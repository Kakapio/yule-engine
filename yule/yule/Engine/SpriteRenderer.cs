using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace yule.Engine
{
    /// <summary>
    /// Used to render sprites.
    /// </summary>
    public class SpriteRenderer : Component
    {
        public Texture2D Sprite { get; set; }
        public Color Color { get; set; }
        public Rectangle Dimensions { get; set; } //Used for testing purposes.
        
        public override void Initialize()
        {
            Sprite = DefaultSprites.WhiteSquare;
            Color = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
            Sprite = DefaultSprites.WhiteSquare;
        }
    }
}