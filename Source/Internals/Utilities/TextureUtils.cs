using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BTDMG.Source.Internals.Utilities
{
    public static class TextureUtils
    {
        public static Texture2D LoadTex2D(this ContentManager manager, string assetName) =>
            manager.Load<Texture2D>(assetName);

        /// <summary>
        ///     Opens a <see cref="FileStream" /> and loads a <see cref="Texture2D" />.
        /// </summary>
        /// <param name="filePath">The path to the file you want to load.</param>
        /// <param name="graphicsDevice">The <see cref="GraphicsDevice" /></param>
        /// to be used for loading the
        /// <see cref="Texture2D" />
        /// .
        /// <returns>The newly-loaded <see cref="Texture2D" />.</returns>
        public static Texture2D LoadTex2D(string filePath, GraphicsDevice graphicsDevice)
        {
            using FileStream stream = new(filePath, FileMode.Open);
            return Texture2D.FromStream(graphicsDevice, stream);
        }

        /// <summary>
        ///     Creates a <see cref="Vector2" /> using the <see cref="Texture2D.Width" /> and <see cref="Texture2D.Height" /> of
        ///     the <paramref name="texture" />/
        /// </summary>
        /// <param name="texture">The <see cref="Texture2D" /> instance you want to retrieve the size of.</param>
        /// <returns>A <see cref="Vector2" /> with the dimensions of the <see cref="Texture2D" />.</returns>
        public static Vector2 Size(this Texture2D texture) => new(texture.Width, texture.Height);
    }
}