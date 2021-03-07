using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BTDMG.Internals.DataStructures.Drawing
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
    }
}