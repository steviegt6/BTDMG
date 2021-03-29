using Microsoft.Xna.Framework;

namespace BTDMG.Source.Internals.Framework.DataStructures.Time
{
    /// <summary>
    ///     A struct that holds two instances of <see cref="TimeData"/>, a cached instance and an up-to-date instance to compare against.
    /// </summary>
    public struct TimeCapsule
    {
        /// <summary>
        ///     The current time.
        /// </summary>
        public TimeData currentTime;

        /// <summary>
        ///     The cached time to compare against <see cref="currentTime"/>.
        /// </summary>
        public TimeData cachedTime;

        public TimeCapsule(TimeData currentTime, TimeData cachedTime)
        {
            this.currentTime = currentTime;
            this.cachedTime = cachedTime;
        }

        public TimeCapsule(TimeData cloneTime) => currentTime = cachedTime = cloneTime;

        public void UpdateCache(GameTime time, long ticks = -1)
        {
            if (ticks == -1)
                ticks = time.TotalGameTime.Ticks;

            cachedTime = new TimeData(ticks, time);
        }

        public bool Valid(int threshold) => currentTime.tick - cachedTime.tick >= threshold;
    }
}
