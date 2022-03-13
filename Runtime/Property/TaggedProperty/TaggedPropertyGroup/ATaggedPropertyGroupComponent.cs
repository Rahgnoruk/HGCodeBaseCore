using UnityEngine;

namespace HyperGnosys.Core
{
    public abstract class ATaggedPropertyGroupComponent<PropertyType> : MonoBehaviour, ITaggedPropertyGroup<PropertyType>
    {
        [SerializeField] private TaggedPropertyGroup<PropertyType> propertyGroup;
        public TaggedProperty<PropertyType> GetPropertyByTag(PropertyTag tag)
        {
            return propertyGroup.GetPropertyByTag(tag);
        }
    }
}