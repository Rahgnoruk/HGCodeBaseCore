using System;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class Attributes : IAttributes
    {
        [SerializeField] private TaggedPropertyGroup<float> floatAttributes;
        [SerializeField] private TaggedPropertyGroup<string> stringAttributes;
        [SerializeField] private TaggedPropertyGroup<bool> boolAttributes;
        [SerializeField] private TaggedPropertyGroup<int> intAttributes;
        [SerializeField] private TaggedPropertyGroup<double> doubleAttributes;
        [SerializeField] private TaggedPropertyGroup<Vector3> vector3Attributes;
        [SerializeField] private TaggedPropertyGroup<GameObject> gameObjectAttributes;
        public AttributeType GetValue<AttributeType>(PropertyTag attributeTag)
        {
            TaggedProperty<AttributeType> attribute = GetAttribute<AttributeType>(attributeTag);
            return attribute.Property.Value;
        }
        public TaggedProperty<AttributeType> GetAttribute<AttributeType>(PropertyTag attributeTag)
        {
            TaggedProperty<AttributeType> attribute = new TaggedProperty<AttributeType>();
            if(GetAttribute(stringAttributes, attributeTag, ref attribute))
            {
                return attribute;
            }
            if (GetAttribute(floatAttributes, attributeTag, ref attribute))
            {
                return attribute;
            }
            if (GetAttribute(boolAttributes, attributeTag, ref attribute))
            {
                return attribute;
            }
            if (GetAttribute(intAttributes, attributeTag, ref attribute))
            {
                return attribute;
            }
            if (GetAttribute(doubleAttributes, attributeTag, ref attribute))
            {
                return attribute;
            }
            if (GetAttribute(vector3Attributes, attributeTag, ref attribute))
            {
                return attribute;
            }
            if (GetAttribute(gameObjectAttributes, attributeTag, ref attribute))
            {
                return attribute;
            }
            return null;
        }
        private bool GetAttribute<ListType, AttributeType>(TaggedPropertyGroup<ListType> attributeList,
            PropertyTag attributeTag, ref TaggedProperty<AttributeType> attribute)
        {
            if (attributeList.ItemType != typeof(AttributeType))
            {
                return false;
            }
            attribute = attributeList.GetPropertyByTag(attributeTag) as TaggedProperty<AttributeType>;
            if (attribute != null)
            {
                return true;
            }
            return false;
        }

        public bool SetAttributeValue<AttributeType>(PropertyTag attributeTag, AttributeType newValue)
        {
            TaggedProperty<AttributeType> attribute = new TaggedProperty<AttributeType>();
            if (GetAttribute(stringAttributes, attributeTag, ref attribute))
            {
                attribute.Property.Value = newValue;
                return true;
            }
            if (GetAttribute(floatAttributes, attributeTag, ref attribute))
            {
                attribute.Property.Value = newValue;
                return true;
            }
            if (GetAttribute(boolAttributes, attributeTag, ref attribute))
            {
                attribute.Property.Value = newValue;
                return true;
            }
            if (GetAttribute(intAttributes, attributeTag, ref attribute))
            {
                attribute.Property.Value = newValue;
                return true;
            }
            if (GetAttribute(doubleAttributes, attributeTag, ref attribute))
            {
                attribute.Property.Value = newValue;
                return true;
            }
            if (GetAttribute(vector3Attributes, attributeTag, ref attribute))
            {
                attribute.Property.Value = newValue;
                return true;
            }
            if (GetAttribute(gameObjectAttributes, attributeTag, ref attribute))
            {
                attribute.Property.Value = newValue;
                return true;
            }
            return false;
        }
    }
}