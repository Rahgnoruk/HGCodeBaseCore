using System;
using System.Collections.Generic;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class TaggedPropertyGroup<AttributeType>
    {
        [SerializeField] private Type itemType = typeof(AttributeType);
        [SerializeField] private List<TaggedProperty<AttributeType>> list = new List<TaggedProperty<AttributeType>>();

        public TaggedProperty<AttributeType> FindAttribute(PropertyTag tag)
        {
            foreach(TaggedProperty<AttributeType> attribute in list)
            {
                if (attribute.Tag.Equals(tag))
                {
                    return attribute;
                }
            }
            return null;
        }

        public Type ItemType { get => itemType; set => itemType = value; }
        public List<TaggedProperty<AttributeType>> List { get => list; set => list = value; }
    }
}