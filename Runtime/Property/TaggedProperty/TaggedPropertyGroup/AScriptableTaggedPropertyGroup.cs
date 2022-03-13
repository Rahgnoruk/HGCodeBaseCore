using UnityEngine;

namespace HyperGnosys.Core
{
    public abstract class AScriptableTaggedPropertyGroup<PropertyType> : ScriptableObject, ITaggedPropertyGroup<PropertyType>
    {
        [SerializeField] private TaggedPropertyGroup<PropertyType> propertyGroup;
        public TaggedProperty<PropertyType> GetPropertyByTag(PropertyTag tag)
        {
            return propertyGroup.GetPropertyByTag(tag);
        }
    }
}