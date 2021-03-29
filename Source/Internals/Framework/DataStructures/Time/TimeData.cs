using Microsoft.Xna.Framework;

namespace BTDMG.Source.Internals.Framework.DataStructures.Time
{
    /// <summary>
    ///     A struct that holds a saved <c>tick</c> value and <see cref="GameTime"/> instance.
    /// </summary>
    public readonly struct TimeData
    {
        public readonly long tick;
        public readonly GameTime time;

        public TimeData(long tick, GameTime time)
        {
            this.tick = tick;
            this.time = time;
        }
    }
}
