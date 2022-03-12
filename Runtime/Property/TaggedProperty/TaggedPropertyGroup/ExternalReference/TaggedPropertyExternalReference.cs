using System;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class TaggedPropertyExternalReference<PropertyGroupType> : ISerializationCallbackReceiver
    {
        [SerializeField] private ExternalReference<ITaggedPropertyGroup<PropertyGroupType>> propertyGroup 
            = new ExternalReference<ITaggedPropertyGroup<PropertyGroupType>>();
        [SerializeField] private PropertyTag tag;
        [SerializeField] private TaggedProperty<PropertyGroupType> referencedProperty;

        public void OnBeforeSerialize()
        {
            if (propertyGroup.Reference == null || tag == null)
            {
                return;
            }
            referencedProperty = propertyGroup.Reference.GetPropertyByTag(tag);
        }

        public void OnAfterDeserialize()
        {
        }

        public TaggedProperty<PropertyGroupType> ReferencedProperty => referencedProperty;
    }
}