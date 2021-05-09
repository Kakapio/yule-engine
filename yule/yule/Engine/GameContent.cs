using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace yule.Engine
{
    /// <summary>
    /// Contents all run-time game assets in dictionaries.
    /// </summary>
    public static class GameContent
    {
        public static readonly Dictionary<string, Texture2D> Textures = new Dictionary<string, Texture2D>();

        public static void Load(ContentManager content)
        {
            Textures.Add("dirt", content.Load<Texture2D>("dirt"));
        }
    }
}