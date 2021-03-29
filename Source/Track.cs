using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTDMG.Source
{
    public class Track
    {
        /// <summary>
        /// All possible paths within the track that bloons can follow.
        /// </summary>
        public List<Path> Paths = new List<Path>();

        public Track()
        {
            Paths = new List<Path>();
        }

        /// <summary>
        /// Gets the position of a <see cref="Bloon"/> on the path.
        /// </summary>
        /// <param name="bloon"></param>
        /// <returns></returns>
        public Vector2 GetPathPosition(Bloon bloon)
        {
            float progress = bloon.Progress;
            float guess = -1;
            int point = 0;
            Path path = Paths[bloon.Path];
            if (path.Escape <= bloon.Progress)
            {
                bloon.Escape();
            }
            foreach (float dist in Paths[bloon.Path].PathLengths)
            {
                if (guess < progress)
                {
                    point++;
                    guess += dist;
                }
            }
            Vector2 point1 = path.PathPoints[point - 1];
            Vector2 point2 = path.PathPoints[point];

            Vector2 relative = point2 - point1;

            float length1 = guess - path.PathLengths[point - 1];
            float length2 = guess;

            float lengthRelative = length2 - length1;

            float toNextPoint = bloon.Progress - length1;
            toNextPoint /= lengthRelative;

            Vector2 fromPoint = relative * toNextPoint;
            return fromPoint + point1;
        }
    }
}
