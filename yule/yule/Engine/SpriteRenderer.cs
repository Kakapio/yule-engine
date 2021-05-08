using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using yule.ECS;

namespace yule.Engine
{
    /// <summary>
    /// Used to render sprites.
    /// </summary>
    public class SpriteRenderer : IComponent
    {
        public Texture2D Sprite { get; set; }
        public Color Color { get; set; }
        
        public void Initialize()
        {
            Sprite = DefaultSprites.WhiteSquare;
            Color = Color.White;
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}