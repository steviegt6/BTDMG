using Microsoft.Xna.Framework;

namespace BTDMG.Source.Internals.Framework.DataStructures.Time
{
    /// <summary>
    ///     Not a struct, but a class that holds two instances of <see cref="TimeData"/>, a cached instance and an up-to-date instance to compare against.
    /// </summary>
    public class TimeCapsule
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

        public TimeCapsule(GameTime time, long ticks)
        {
            currentTime = new TimeData(ticks, time);
            cachedTime = new TimeData(0, time);
        }

        public void UpdateCache(GameTime time, long ticks) => cachedTime = new TimeData(ticks, time);

        public void UpdateCurrent(GameTime time, long ticks) => currentTime = new TimeData(ticks, time);

        public bool Valid(int threshold) => currentTime.tick - cachedTime.tick >= threshold;
    }
}
