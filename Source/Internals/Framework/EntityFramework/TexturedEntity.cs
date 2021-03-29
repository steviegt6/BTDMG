using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BTDMG.Source.Internals.Framework.EntityFramework
{
    /// <summary>
    ///     An <see cref="Entity"/> with an associated <see cref="Texture2D"/> and <see cref="Color"/> for tinting.
    /// </summary>
    public abstract class TexturedEntity : Entity
    {
        /// <summary>
        ///     The texture a <see cref="TexturedEntity"/> is visually represented by.
        /// </summary>
        public virtual Texture2D Texture { get; set; }

        /// <summary>
        ///     The <see cref="Color"/> of the tint that should be applied while drawing. Defaults to <see cref="Color.White"/>.
        /// </summary>
        public virtual Color Tint { get; set; } = Color.White;

        public static implicit operator Texture2D(TexturedEntity entity) => entity.Texture;
    }
}
