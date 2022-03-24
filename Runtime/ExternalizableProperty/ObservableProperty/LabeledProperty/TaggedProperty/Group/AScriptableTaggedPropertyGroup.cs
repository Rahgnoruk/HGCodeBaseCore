using UnityEngine;

namespace HyperGnosys.Core
{
    public abstract class AScriptableTaggedPropertyGroup<PropertyType> : ScriptableObject, ITaggedPropertyGroup<PropertyType>
    {
        [SerializeField] private TaggedPropertyGroup<PropertyType> propertyGroup;

        public TaggedProperty<PropertyType> this[PropertyTag tag]
        { 
            get => propertyGroup[tag];
            set => propertyGroup[tag] = value;
        }
    }
}