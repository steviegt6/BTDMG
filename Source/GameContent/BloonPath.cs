using Microsoft.Xna.Framework;

namespace BTDMG.Source.GameContent
{
    /// <summary>
    ///     Simple class that contains info for track paths.
    /// </summary>
    public class BloonPath
    {
        public BloonPath(Vector2[] pathPoints)
        {
            PathPoints = pathPoints;
            PathLengths = new float[pathPoints.Length - 1];

            for (int i = 1; i < PathPoints.Length; i++)
                PathLengths[i - 1] = Vector2.Distance(PathPoints[i - 1], PathPoints[i]);

            foreach (float dist in PathLengths)
                EscapeDistance += dist;
        }

        /// <summary>
        ///     A list of all the points on the path. <br />
        ///     The first <see cref="Vector2" /> in the array is the entrance and the last is the exit.
        /// </summary>
        public Vector2[] PathPoints { get; }

        /// <summary>
        ///     The distance between pairs of sequential path points.
        /// </summary>
        public float[] PathLengths { get; }

        /// <summary>
        ///     The distance bloons must travel to escape the path.
        /// </summary>
        public float EscapeDistance { get; }
    }
}