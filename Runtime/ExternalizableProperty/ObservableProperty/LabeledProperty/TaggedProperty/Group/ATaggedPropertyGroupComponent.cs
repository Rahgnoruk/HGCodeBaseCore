using UnityEngine;

namespace HyperGnosys.Core
{
    public abstract class ATaggedPropertyGroupComponent<PropertyType> : MonoBehaviour, ITaggedPropertyGroup<PropertyType>
    {
        [SerializeField] private TaggedPropertyGroup<PropertyType> propertyGroup;
        public TaggedProperty<PropertyType> this[PropertyTag tag]
        {
            get => propertyGroup[tag];
            set => propertyGroup[tag] = value;
        }
    }
}