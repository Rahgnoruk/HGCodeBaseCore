using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class ExternalizableLabeledProperty<ContainedType> : IObservableProperty<ContainedType>
    {
        [SerializeField] private bool debugExternalizableTaggedProperty = false;
        [SerializeField] private bool useExternalProperty = false;
        [SerializeField] private NamedProperty<ContainedType> localProperty = new NamedProperty<ContainedType>();
        [SerializeField] private TaggedPropertyInGroup<ContainedType> propertyInGroup;
        public string Label
        {
            get
            {
                if (useExternalProperty)
                {
                    HGDebug.Log($"Accessing External Tagged Property", debugExternalizableTaggedProperty);
                    return propertyInGroup.ReferencedProperty.Tag.name;
                }
                else
                {
                    return localProperty.Name;
                }
            }
        }
        public virtual ContainedType Value
        {
            get
            {
                if (useExternalProperty)
                {
                    HGDebug.Log($"Accessing External Tagged Property", debugExternalizableTaggedProperty);
                    return propertyInGroup.ReferencedProperty.Value;
                }
                else
                {
                    return localProperty.Value;
                }
            }
            set
            {
                if (useExternalProperty)
                {
                    propertyInGroup.ReferencedProperty.Value = value;
                }
                else
                {
                    localProperty.Value = value;
                }
            }
        }
        public void AddListener(IGameEventListener<ContainedType> listener)
        {
            if (useExternalProperty)
            {
                propertyInGroup.ReferencedProperty.AddListener(listener);
            }
            else
            {
                localProperty.AddListener(listener);
            }
        }
        public void RemoveListener(IGameEventListener<ContainedType> listener)
        {
            if (useExternalProperty)
            {
                propertyInGroup.ReferencedProperty.RemoveListener(listener);
            }
            else
            {
                localProperty.RemoveListener(listener);
            }
        }
        public void AddListener(UnityAction<ContainedType> listener)
        {
            if (useExternalProperty)
            {
                propertyInGroup.ReferencedProperty.AddListener(listener);
            }
            else
            {
                localProperty.AddListener(listener);
            }
        }
        public void RemoveListener(UnityAction<ContainedType> listener)
        {
            if (useExternalProperty)
            {
                propertyInGroup.ReferencedProperty.RemoveListener(listener);
            }
            else
            {
                localProperty.RemoveListener(listener);
            }
        }
    }
}