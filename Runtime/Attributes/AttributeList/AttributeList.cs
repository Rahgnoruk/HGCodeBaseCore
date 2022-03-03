using System;
using System.Collections.Generic;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class AttributeList<AttributeType>
    {
        [SerializeField] private Type itemType = typeof(AttributeType);
        [SerializeField] private List<Attribute<AttributeType>> list = new List<Attribute<AttributeType>>();

        public Attribute<AttributeType> FindAttribute(AttributeTag tag)
        {
            foreach(Attribute<AttributeType> attribute in list)
            {
                if (attribute.Tag.Equals(tag))
                {
                    return attribute;
                }
            }
            return null;
        }

        public Type ItemType { get => itemType; set => itemType = value; }
        public List<Attribute<AttributeType>> List { get => list; set => list = value; }
    }
}