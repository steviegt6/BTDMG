using System;

namespace BTDMG.Source.Internals.Framework.AssetFramework
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AssetPointerAttribute : Attribute
    {
        public string AssetPath { get; }

        public AssetPointerAttribute(string assetPath) => AssetPath = assetPath;
    }
}
