using BTDMG.Source.GameContent.Assets;
using Microsoft.Xna.Framework.Content;

namespace BTDMG.Source.Internals.Utilities
{
    // TODO: Mods will use their own asset loader.
    /// <summary>
    ///     Class in charge of handling the loading of regular vanilla assets.
    /// </summary>
    public static class AssetLoader
    {
        internal static void Load(ContentManager contentManager) => LoadTextures(contentManager);

        private static void LoadTextures(ContentManager contentManager) =>
            Assets.CursorTexture = contentManager.LoadTex2D("Textures/Cursor");
    }
}