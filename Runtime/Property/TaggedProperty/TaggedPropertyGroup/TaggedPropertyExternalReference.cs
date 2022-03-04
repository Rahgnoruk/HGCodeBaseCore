using System;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class TaggedPropertyExternalReference<PropertyGroupContainedType> : ISerializationCallbackReceiver
    {
        [SerializeField] private PropertyTag tag;
        [SerializeField] private TaggedPropertyGroupComponent<PropertyGroupContainedType> propertyGroup;
        [SerializeField] private TaggedProperty<PropertyGroupContainedType> taggedProperty;

        public void OnBeforeSerialize()
        {
            if (propertyGroup == null)
            {
                return;
            }
            taggedProperty = propertyGroup.Value.FindAttribute(tag);
        }

        public void OnAfterDeserialize()
        {
        }

        public TaggedProperty<PropertyGroupContainedType> ExternalTaggedProperty => taggedProperty;
    }
}