using BTDMG.Source.GameContent.Assets;
using BTDMG.Source.Internals.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BTDMG.Source.Internals.DataStructures.Drawing
{
    /// <summary>
    ///     Struct containing information about how to draw the cursor.
    /// </summary>
    public struct CursorDrawOptions
    {
        /// <summary>
        ///     Whether or not any cursor should be drawn at all.
        /// </summary>
        public bool shouldDrawCursor;

        /// <summary>
        ///     Whether or not the custom cursor's texture should be drawn.
        /// </summary>
        public bool drawCustomCursorTexture;

        /// <summary>
        ///     The custom texture to draw if <see cref="drawCustomCursorTexture" /> is <c>true</c>.
        /// </summary>
        public Texture2D customCursorTexture;

        /// <summary>
        ///     The color to tint the custom cursor.
        /// </summary>
        public Color customCursorTint;

        public CursorDrawOptions(bool shouldDrawCursor, bool drawCustomCursorTexture, Texture2D customCursorTexture,
            Color customCursorTint = default)
        {
            if (customCursorTint == default)
                customCursorTint = Color.White;

            this.shouldDrawCursor = shouldDrawCursor;
            this.drawCustomCursorTexture = drawCustomCursorTexture;
            this.customCursorTexture = customCursorTexture;
            this.customCursorTint = customCursorTint;
        }

        /// <summary>
        ///     Draw the cursor in accordance to the provided <see cref="CursorDrawOptions" /> instance.
        /// </summary>
        /// <param name="cursorDrawOptions">The instance of <see cref="CursorDrawOptions" /> to use.</param>
        /// <param name="spriteBatch">The instance of <see cref="SpriteBatch" /> used to draw the custom cursor.</param>
        public static void Draw(CursorDrawOptions cursorDrawOptions, SpriteBatch spriteBatch)
        {
            if (cursorDrawOptions.shouldDrawCursor)
            {
                BTDGame.Instance.IsMouseVisible = !cursorDrawOptions.drawCustomCursorTexture &&
                                                  cursorDrawOptions.customCursorTexture != null;

                if (!cursorDrawOptions.drawCustomCursorTexture)
                    return;

                try
                {
                    spriteBatch.Draw(cursorDrawOptions.customCursorTexture, Mouse.GetState().Position.ToVector2(), null,
                        cursorDrawOptions.customCursorTint, 0f, Assets.CursorTexture.Size() / 2f, Vector2.One,
                        SpriteEffects.None, 1f);
                }
                catch
                {
                    if (cursorDrawOptions.customCursorTexture == null)
                    {
                        // todo: log4net
                    }
                }
            }
            else
                BTDGame.Instance.IsMouseVisible = false;
        }
    }
}