using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTDMG.Source
{
    public class Path
    {
        /// <summary>
        /// A list of all the points on the path. The first <see cref="Vector2"/> in the array is the entrance and the last is the exit.
        /// </summary>
        public Vector2[] PathPoints;

        /// <summary>
        /// The distance between pairs of sequential path points.
        /// </summary>
        public float[] PathLengths;

        /// <summary>
        /// The distance bloons must travel to escape the path.
        /// </summary>
        public float Escape;

        public Path(Vector2[] points)
        {
            PathLengths = new float[points.Length - 1];
            for (int i = 1; i < PathPoints.Length; i++)
            {
                PathLengths[i - 1] = Vector2.Distance(PathPoints[i - 1], PathPoints[i]);
            }
            foreach (float dist in PathLengths)
            {
                Escape += dist;
            }
        }
    }
}
