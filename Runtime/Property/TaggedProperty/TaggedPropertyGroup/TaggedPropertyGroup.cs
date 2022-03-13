using System;
using System.Collections.Generic;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class TaggedPropertyGroup<PropertyType> : ITaggedPropertyGroup<PropertyType>
    {
        [SerializeField] private Type itemType = typeof(PropertyType);
        [SerializeField] private List<TaggedProperty<PropertyType>> list = new List<TaggedProperty<PropertyType>>();

        public TaggedProperty<PropertyType> GetPropertyByTag(PropertyTag tag)
        {
            foreach(TaggedProperty<PropertyType> property in list)
            {
                if (!property.Tag) {
                    Debug.LogWarning("Theres a Tagged Property Group containing a Property with no tag.");
                    continue; 
                }
                if (property.Tag.Equals(tag))
                {
                    return property;
                }
            }
            return null;
        }

        public Type ItemType { get => itemType; set => itemType = value; }
        public List<TaggedProperty<PropertyType>> List { get => list; set => list = value; }
    }
}