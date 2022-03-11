using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class ExternalizableTaggedProperty<ContainedType> : IObservableProperty<ContainedType>
    {
        [SerializeField] private bool debugExternalizableTaggedProperty = false;
        [SerializeField] private bool useExternalProperty = false;
        [SerializeField] private TaggedProperty<ContainedType> localProperty;
        [SerializeField] private TaggedPropertyExternalReference<ContainedType> externalProperty;
        public virtual ContainedType Value
        {
            get
            {
                if (useExternalProperty)
                {
                    HGDebug.Log($"Accessing External Tagged Property", debugExternalizableTaggedProperty);
                    return externalProperty.ReferencedProperty.Property.Value;
                }
                else
                {
                    return localProperty.Property.Value;
                }
            }
            set
            {
                if (useExternalProperty)
                {
                    externalProperty.ReferencedProperty.Property.Value = value;
                }
                else
                {
                    localProperty.Property.Value = value;
                }
            }
        }
        public void AddListener(IGameEventListener<ContainedType> listener)
        {
            if (externalProperty.ReferencedProperty != null)
            {
                externalProperty.ReferencedProperty.Property.AddListener(listener);
            }
            else
            {
                localProperty.Property.AddListener(listener);
            }
        }
        public void RemoveListener(IGameEventListener<ContainedType> listener)
        {
            if (externalProperty.ReferencedProperty != null)
            {
                externalProperty.ReferencedProperty.Property.RemoveListener(listener);
            }
            else
            {
                localProperty.Property.RemoveListener(listener);
            }
        }
        public void AddListener(UnityAction<ContainedType> listener)
        {
            if (externalProperty.ReferencedProperty != null)
            {
                externalProperty.ReferencedProperty.Property.AddListener(listener);
            }
            else
            {
                localProperty.Property.AddListener(listener);
            }
        }
        public void RemoveListener(UnityAction<ContainedType> listener)
        {
            if (externalProperty.ReferencedProperty != null)
            {
                externalProperty.ReferencedProperty.Property.RemoveListener(listener);
            }
            else
            {
                localProperty.Property.RemoveListener(listener);
            }
        }
    }
}