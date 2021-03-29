using BTDMG.Source.Internals.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace BTDMG.Source.Internals.DataStructures.Drawing
{
    public readonly struct CursorOptions
    {
        public bool DrawCursor { get; }

        public bool DrawCustomCursorTexture { get; }

        public Texture2D CustomCursorTexture { get; }

        public Color CursorColor { get; }

        public CursorOptions(bool drawCursor, bool drawCustomCursorTexture, Texture2D customCursorTexture,
            Color cursorColor)
        {
            DrawCursor = drawCursor;
            DrawCustomCursorTexture = drawCustomCursorTexture;
            CustomCursorTexture = customCursorTexture;
            CursorColor = cursorColor;
        }

        public CursorOptions(bool drawCursor, bool drawCustomCursorTexture, Texture2D customCursorTexture)
        {
            DrawCursor = drawCursor;
            DrawCustomCursorTexture = drawCustomCursorTexture;
            CustomCursorTexture = customCursorTexture;
            CursorColor = Color.White;
        }

        public static void Draw(CursorOptions cursorOptions, SpriteBatch spriteBatch)
        {
            if (cursorOptions.DrawCursor)
            {
                BTDGame.Instance.IsMouseVisible = !cursorOptions.DrawCustomCursorTexture;

                if (cursorOptions.DrawCustomCursorTexture)
                {
                    spriteBatch.Draw(cursorOptions.CustomCursorTexture, Mouse.GetState().Position.ToVector2(), null,
                        cursorOptions.CursorColor, 0f, Assets.Assets.CursorTexture.Size() / 2f, Vector2.One,
                        SpriteEffects.None, 1f);
                }
            }
            else
            {
                BTDGame.Instance.IsMouseVisible = false;
            }
        }
    }
}