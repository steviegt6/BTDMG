#nullable enable
using System;
using System.Reflection;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace BTDMG.Source.Internals.Framework.AssetFramework
{
    public static class AssetLoader
    {
        internal static void LoadAssets()
        {
            foreach (Type type in typeof(AssetLoader).Assembly.GetTypes())
            {
                AssetClassAssignmentAttribute? assetClassAssignment = type.GetCustomAttribute<AssetClassAssignmentAttribute>();

                if (assetClassAssignment == null)
                    continue;

                Type assetType = assetClassAssignment.AssetType;

                foreach (FieldInfo field in type.GetFields())
                {
                    AssetPointerAttribute? assetPointer = field.GetCustomAttribute<AssetPointerAttribute>();

                    if (assetPointer == null)
                        continue;

                    ParseGivenTypeAsAsset(assetType, assetPointer.AssetPath, out object? asset);

                    if (asset == null)
                        throw new ArgumentNullException("Unable to load asset as no corresponding asset type was found: " + assetType.FullName);

                    field.SetValue(null, asset);
                }
            }
        }

        private static void ParseGivenTypeAsAsset(Type type, string assetPath, out object? asset)
        {
            ContentManager contentManager = BTDGame.Instance.Content;
            asset = null;

            if (type == typeof(Texture2D))
                asset = contentManager.Load<Texture2D>(assetPath);
        }
    }
}
