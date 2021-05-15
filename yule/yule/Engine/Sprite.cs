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

        private Transform transform;

        public Sprite()
        {
            SpriteSystem.Register(this);
        }
        
        public override void Initialize()
        {
            Texture = DefaultSprites.WhiteSquare;
            Color = Color.White;
            transform = Owner.GetComponent<Transform>();
        }

        public override void Update(GameTime gameTime)
        {
            Texture = DefaultSprites.WhiteSquare;
        }

        public void Render(SpriteBatch spriteBatch, bool debugMode = false)
        {
            if (Dimensions.IsEmpty)
                spriteBatch.Draw(Texture, transform.Position, Color);
            else
                spriteBatch.Draw(Texture, new Rectangle((int)transform.Position.X, (int)transform.Position.Y,
                    Dimensions.Width, Dimensions.Height), Color);
            
            //Rendering code to show colliders
            if (debugMode)
            {
                if (Owner.GetComponent<Collider>() != null)
                {
                    RenderColliderOutline(spriteBatch);
                }
            }
        }
        
        private void RenderColliderOutline(SpriteBatch spriteBatch)
        {
            int posX = (int) transform.Position.X;
            int posY = (int) transform.Position.Y;
            Box collider = Owner.GetComponent<Collider>().Dimensions;
            
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(posX, posY,
                2, (int)collider.Height), Color.Fuchsia); // Left
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(posX + (int)collider.Width, posY,
                2, (int)collider.Height), Color.Fuchsia); // Right
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(posX, posY,
                (int)collider.Width, 2), Color.Fuchsia); // Top
            spriteBatch.Draw(DefaultSprites.WhiteSquare, new Rectangle(posX, posY + (int)collider.Height,
                (int)collider.Width + 2, 2), Color.Fuchsia); // Bottom TODO investigate
        }
    }
}