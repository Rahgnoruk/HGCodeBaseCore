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
        private TaggedProperty<PropertyGroupType> property = null;

        public void OnBeforeSerialize()
        {
            if (propertyGroup.Reference == null || tag == null)
            {
                propertyPreview = null;
                return;
            }
            propertyPreview = propertyGroup.Reference.GetPropertyByTag(tag);
        }

        public void OnAfterDeserialize()
        {
        }

        public TaggedProperty<PropertyGroupType> ReferencedProperty
        {
            get
            {
                if(property == null)
                {
                    property = propertyGroup.Reference.GetPropertyByTag(tag);
                }
                return property;
            }
        }
    }
}