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
        ///     Gets the position of a <see cref="Bloon" /> on the path.
        /// </summary>
        /// <param name="bloon"></param>
        /// <returns></returns>
        public Vector2 GetBloonPosition(Bloon bloon)
        {
            BloonPath bloonPath = Paths[bloon.path];
            float guess = -1;
            int point = 0;

            if (bloonPath.EscapeDistance <= bloon.pathProgress)
                bloon.Escape();

            foreach (float dist in Paths[bloon.path].PathLengths.Where(x => guess < bloon.pathProgress))
            {
                point++;
                guess += dist;
            }

            Vector2 pathPoint = bloonPath.PathPoints[point - 1];
            float guessLength = guess - bloonPath.PathLengths[point - 1];
            float toNextPoint = (bloon.pathProgress - guessLength) / guess - guessLength;

            return (bloonPath.PathPoints[point] - pathPoint) * toNextPoint + pathPoint;
        }
    }
}