using Microsoft.Xna.Framework;

namespace BTDMG.Source.GameContent
{
    /// <summary>
    ///     The class containing information about a Bloon.
    /// </summary>
    public abstract class Bloon
    {
        /// <summary>
        ///     Normally calls <see cref="BloonTrack.GetPositionFromPath{T}" />, but can be overridden to whatever you want.
        /// </summary>
        /// <returns></returns>
        public virtual Vector2 GetPositionOnPath() => Track.GetPositionFromPath(this, Path);

        /// <summary>
        ///     Called when a bloon escapes a path.
        /// </summary>
        public virtual void OnEscape() { }

        #region Path Stuff

        /// <summary>
        ///     The <see cref="Bloon" />'s associated path. <br />
        ///     This should never be used outside of <see cref="GetPath" /> and <see cref="SetPath" />, instead, use
        ///     <see cref="Path" />.
        /// </summary>
        private BloonPath _path;

        /// <summary>
        ///     The path the <see cref="Bloon" /> is on.
        /// </summary>
        public BloonPath Path
        {
            get => GetPath();

            set => SetPath(value);
        }

        /// <summary>
        ///     Allows you to run any code or intercept <see cref="Path" />'s getter, allowing you to decide whether or not it
        ///     should return <see cref="_path" /> or your own, separate <see cref="BloonPath" />.
        /// </summary>
        /// <returns></returns>
        protected virtual BloonPath GetPath() => _path;

        /// <summary>
        ///     Allows you to run any code or intercept <see cref="Path" />'s setter, allowing you to decide whether or not
        ///     <see cref="_path" /> should be changed.
        /// </summary>
        /// <param name="path">The path that <see cref="_path" /> is trying to be set to.</param>
        protected virtual void SetPath(BloonPath path) => _path = path;

        #endregion

        #region Track Stuff

        /// <summary>
        ///     The <see cref="Bloon" />'s associated track.
        ///     This should never be used outside of <see cref="GetTrack" /> and <see cref="SetTrack" />, instead, use
        ///     <see cref="Track" />.
        /// </summary>
        private BloonTrack _track;

        /// <summary>
        ///     The track the <see cref="Bloon" /> is on.
        /// </summary>
        public BloonTrack Track
        {
            get => GetTrack();

            set => SetTrack(value);
        }

        /// <summary>
        ///     Allows you to run any code or intercept <see cref="Track" />'s getter, allowing you to decide whether or not it
        ///     should return <see cref="_track" /> or your own, separate <see cref="BloonTrack" />.
        /// </summary>
        /// <returns></returns>
        protected virtual BloonTrack GetTrack() => _track;

        /// <summary>
        ///     Allows you to run any code or intercept <see cref="Track" />'s setter, allowing you to decide whether or not
        ///     <see cref="_track" /> should be changed.
        /// </summary>
        /// <param name="track">The track that <see cref="_track" /> is trying to be set to.</param>
        protected virtual void SetTrack(BloonTrack track) => _track = track;

        #endregion

        #region Progress Stuff

        /// <summary>
        ///     The <see cref="Bloon" />'s progress along its <see cref="Path" />.
        ///     This should never be used outside of <see cref="GetProgress" /> and <see cref="SetProgress" />, instead, use
        ///     <see cref="Progress" />.
        /// </summary>
        private float _progress;

        /// <summary>
        ///     The <see cref="Bloon" />'s progress along its <see cref="Path" />.
        /// </summary>
        public float Progress
        {
            get => GetProgress();

            set => SetProgress(value);
        }

        /// <summary>
        ///     Allows you to run any code or intercept <see cref="Progress" />' getter, allowing you to decide whether or not it
        ///     should return <see cref="_progress" /> or your own, separate <see cref="float" />.
        /// </summary>
        /// <returns></returns>
        protected virtual float GetProgress() => _progress;

        /// <summary>
        ///     Allows you to run any code or intercept <see cref="Progress" />' setter, allowing you to decide whether or not
        ///     <see cref="_progress" /> should be changed.
        /// </summary>
        /// <param name="progress">The amount of progress that <see cref="_progress" /> is trying to be set to.</param>
        protected virtual void SetProgress(float progress) => _progress = progress;

        #endregion
    }
}