using BTDMG.Source.Internals.Framework.AssetFramework;
using Microsoft.Xna.Framework.Graphics;

namespace BTDMG.Source.GameContent.Assets
{
    [AssetClassAssignment(typeof(Texture2D))]
    public static class TextureAssets
    {
        [AssetPointer("Textures/Cursor")]
        public static Texture2D CursorTexture;
    }
}