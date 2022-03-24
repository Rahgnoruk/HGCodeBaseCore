using System;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class TaggedPropertyInGroup<PropertyGroupType> : ISerializationCallbackReceiver
    {
        [SerializeField] 
        private ExternalReference<ITaggedPropertyGroup<PropertyGroupType>> propertyGroup 
            = new ExternalReference<ITaggedPropertyGroup<PropertyGroupType>>();
        [SerializeField] private PropertyTag tag;
        [SerializeField] private TaggedProperty<PropertyGroupType> propertyPreview;

        public void OnBeforeSerialize()
        {
            if (propertyGroup.Reference == null || tag == null)
            {
                propertyPreview = null;
                return;
            }
            propertyPreview = propertyGroup.Reference[tag];
        }

        public void OnAfterDeserialize()
        {
        }

        public TaggedProperty<PropertyGroupType> ReferencedProperty
        {
            get
            {
                return propertyGroup.Reference[tag];
            }
        }
    }
}