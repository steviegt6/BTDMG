using BTDMG.Source.Internals.Framework.EntityFramework;
using Microsoft.Xna.Framework;

namespace BTDMG.Source.GameContent
{
    /// <summary>
    ///     The class containing information about a <see cref="Bloon"/>. <br />
    ///     Extends <see cref="TexturedEntity"/>.
    /// </summary>
    public abstract class Bloon : TexturedEntity
    {
        /// <summary>
        ///     The path the <see cref="Bloon" /> is on.
        /// </summary>
        public BloonPath Path { get; set; }

        /// <summary>
        ///     The track the <see cref="Bloon" /> is on.
        /// </summary>
        public virtual BloonTrack Track { get; set; }

        /// <summary>
        ///     The <see cref="Bloon" />'s progress along its <see cref="Path" />.
        /// </summary>
        public virtual float Progress { get; set; }

        /// <summary>
        ///     Normally calls <see cref="BloonTrack.GetPositionFromPath{T}" />, but can be overridden to whatever you want.
        /// </summary>
        /// <returns></returns>
        public virtual Vector2 GetPositionOnPath() => Track.GetPositionFromPath(this, Path);

        /// <summary>
        ///     Called when a bloon escapes a path.
        /// </summary>
        public virtual void OnEscape() { }
    }
}