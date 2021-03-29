using Microsoft.Xna.Framework;

namespace BTDMG.Source.Internals.Framework.EntityFramework
{
    /// <summary>
    ///     Contains a position and hit-box property.
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        ///     Represents an <see cref="Entity"/>'s position.
        /// </summary>
        public virtual Vector2 Position { get; set; }

        /// <summary>
        ///     Represents an <see cref="Entity"/>'s hit-box;
        /// </summary>
        public virtual Rectangle HitBox { get; set; }

        public static implicit operator Vector2(Entity entity) => entity.Position;

        public static implicit operator Rectangle(Entity entity) => entity.HitBox;
    }
}
