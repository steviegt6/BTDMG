using System;

namespace BTDMG.Source.Internals.Framework.AssetFramework
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class AssetClassAssignmentAttribute : Attribute
    {
        public Type AssetType { get; }

        public AssetClassAssignmentAttribute(Type assetType) => AssetType = assetType;
    }
}
