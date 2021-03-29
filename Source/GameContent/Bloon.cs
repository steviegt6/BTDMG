namespace BTDMG.Source.GameContent
{
    /// <summary>
    ///     The class containing information about a Bloon.
    /// </summary>
    public abstract class Bloon
    {
        /// <summary>
        ///     The path the bloon is on.
        /// </summary>
        public int path;

        /// <summary>
        ///     The bloon's progress along the path.
        /// </summary>
        public float pathProgress;

        /// <summary>
        ///     Called when a bloon escapes a path.
        /// </summary>
        public virtual void Escape() { }
    }
}