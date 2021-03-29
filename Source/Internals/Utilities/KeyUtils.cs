using System.Linq;
using Microsoft.Xna.Framework.Input;

namespace BTDMG.Source.Internals.Utilities
{
    public static class KeyUtils
    {
        /// <summary>
        ///     Checks whether or not every given <see cref="Keys" /> is down.
        /// </summary>
        /// <param name="keyboardState">The keyboard to check.</param>
        /// <param name="keys">Every key that should be down.</param>
        /// <returns>Whether or not all keys are down.</returns>
        public static bool AreKeysDown(this KeyboardState keyboardState, params Keys[] keys)
        {
            bool areAllDown = true;

            foreach (Keys key in keys)
                if (!keyboardState.IsKeyDown(key))
                {
                    areAllDown = false;
                }

            return areAllDown;
        }

        /// <summary>
        ///     Checks whether or not every given <see cref="Keys" /> is up.
        /// </summary>
        /// <param name="keyboardState">The keyboard to check.</param>
        /// <param name="keys">Every key that should be up.</param>
        /// <returns>Whether or not all keys are up.</returns>
        public static bool AreKeysUp(this KeyboardState keyboardState, params Keys[] keys)
        {
            bool areAllUp = true;

            foreach (Keys key in keys)
                if (!keyboardState.IsKeyUp(key))
                {
                    areAllUp = false;
                }

            return areAllUp;
        }

        /// <summary>
        ///     Checks whether or not any given <see cref="Keys" /> is down.
        /// </summary>
        /// <param name="keyboardState">The keyboard to check.</param>
        /// <param name="keys">Any key that should be down.</param>
        /// <returns>Whether or not at least one key in <paramref name="keys" /> is down.</returns>
        public static bool IsAnyKeyDown(this KeyboardState keyboardState, params Keys[] keys) =>
            keys.Any(keyboardState.IsKeyDown);

        /// <summary>
        ///     Checks whether or not any given <see cref="Keys" /> is up.
        /// </summary>
        /// <param name="keyboardState">The keyboard to check.</param>
        /// <param name="keys">Any key that should be up.</param>
        /// <returns>Whether or not at least one key in <paramref name="keys" /> is up.</returns>
        public static bool IsAnyKeyUp(this KeyboardState keyboardState, params Keys[] keys) =>
            keys.Any(keyboardState.IsKeyUp);
    }
}