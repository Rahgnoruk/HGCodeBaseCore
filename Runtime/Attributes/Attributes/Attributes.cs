using System;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class Attributes : IAttributes
    {
        [SerializeField] private AttributeList<string> stringAttributes;
        [SerializeField] private AttributeList<float> floatAttributes;
        [SerializeField] private AttributeList<bool> boolAttributes;
        [SerializeField] private AttributeList<int> intAttributes;
        [SerializeField] private AttributeList<double> doubleAttributes;
        [SerializeField] private AttributeList<Vector3> vector3Attributes;
        [SerializeField] private AttributeList<GameObject> gameObjectAttributes;
        public AttributeType GetValue<AttributeType>(AttributeTag attributeTag)
        {
            Attribute<AttributeType> attribute = GetAttribute<AttributeType>(attributeTag);
            return attribute.Value;
        }
        public Attribute<AttributeType> GetAttribute<AttributeType>(AttributeTag attributeTag)
        {
            Attribute<AttributeType> attribute = new Attribute<AttributeType>();
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
        private bool GetAttribute<ListType, AttributeType>(AttributeList<ListType> attributeList,
            AttributeTag attributeTag, ref Attribute<AttributeType> attribute)
        {
            if (attributeList.ItemType != typeof(AttributeType))
            {
                return false;
            }
            attribute = attributeList.FindAttribute(attributeTag) as Attribute<AttributeType>;
            if (attribute != null)
            {
                return true;
            }
            return false;
        }

        public bool SetAttributeValue<AttributeType>(AttributeTag attributeTag, AttributeType newValue)
        {
            Attribute<AttributeType> attribute = new Attribute<AttributeType>();
            if (GetAttribute(stringAttributes, attributeTag, ref attribute))
            {
                attribute.Value = newValue;
                return true;
            }
            if (GetAttribute(floatAttributes, attributeTag, ref attribute))
            {
                attribute.Value = newValue;
                return true;
            }
            if (GetAttribute(boolAttributes, attributeTag, ref attribute))
            {
                attribute.Value = newValue;
                return true;
            }
            if (GetAttribute(intAttributes, attributeTag, ref attribute))
            {
                attribute.Value = newValue;
                return true;
            }
            if (GetAttribute(doubleAttributes, attributeTag, ref attribute))
            {
                attribute.Value = newValue;
                return true;
            }
            if (GetAttribute(vector3Attributes, attributeTag, ref attribute))
            {
                attribute.Value = newValue;
                return true;
            }
            if (GetAttribute(gameObjectAttributes, attributeTag, ref attribute))
            {
                attribute.Value = newValue;
                return true;
            }
            return false;
        }
    }
}