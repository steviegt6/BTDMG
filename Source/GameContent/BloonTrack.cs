using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace BTDMG.Source.GameContent
{
    public class BloonTrack
    {
        public BloonTrack() => Paths = new List<BloonPath>();

        /// <summary>
        ///     All possible paths within the track that bloons can follow.
        /// </summary>
        public List<BloonPath> Paths { get; }

        /// <summary>
        ///     Gets the position of something ona path based on the given progress. <br />
        ///     Supports getting the position from <see cref="Bloon"/>s and <see cref="float"/>s.
        /// </summary>
        /// <param name="progress">The amount something has progressed on a path.</param>
        /// <param name="path">The path to check.</param>
        /// <returns></returns>
        public Vector2 GetPositionFromPath<TProgress>(TProgress progress, BloonPath path)
        {
            if (!(progress is Bloon) && !(progress is float))
                throw new InvalidOperationException("Unable to calculate the path based on the given object!");

            float pathProgress = 0f;
            float guess = -1;
            int point = 0;

            switch (progress)
            {
                case Bloon bloon:
                    pathProgress = bloon.pathProgress;

                    if (path.EscapeDistance <= bloon.pathProgress)
                        bloon.OnEscape();
                    break;


                case float rawProgress:
                    pathProgress = rawProgress;
                    break;
            }

            foreach (float dist in path.PathLengths.Where(x => guess < pathProgress))
            {
                point++;
                guess += dist;
            }

            Vector2 pathPoint = path.PathPoints[point - 1];
            float guessLength = guess - path.PathLengths[point - 1];
            float toNextPoint = (pathProgress - guessLength) / guess - guessLength;

            return (path.PathPoints[point] - pathPoint) * toNextPoint + pathPoint;
        }

        public Vector2 GetPositionFromPath(float progress, int path) => GetPositionFromPath(progress, Paths[path]);
    }
}