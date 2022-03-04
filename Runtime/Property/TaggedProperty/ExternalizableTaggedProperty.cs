using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class ExternalizableTaggedProperty<ContainedType> : IObservableProperty<ContainedType>
    {
        [SerializeField] private bool debugExternalizableTaggedProperty = false;
        [SerializeField] private TaggedProperty<ContainedType> localProperty;
        [SerializeField] private TaggedPropertyExternalReference<ContainedType> externalProperty;
        public virtual ContainedType Value
        {
            get
            {
                if (externalProperty.ExternalTaggedProperty != null)
                {
                    HGDebug.Log($"Accessing External Tagged Property", debugExternalizableTaggedProperty);
                    return externalProperty.ExternalTaggedProperty.Value;
                }
                else
                {
                    return localProperty.Value;
                }
            }
            set
            {
                if (externalProperty.ExternalTaggedProperty != null)
                {
                    externalProperty.ExternalTaggedProperty.Value = value;
                }
                else
                {
                    localProperty.Value = value;
                }
            }
        }
        public void AddListener(IGameEventListener<ContainedType> listener)
        {
            if (externalProperty.ExternalTaggedProperty != null)
            {
                externalProperty.ExternalTaggedProperty.AddListener(listener);
            }
            else
            {
                localProperty.AddListener(listener);
            }
        }
        public void RemoveListener(IGameEventListener<ContainedType> listener)
        {
            if (externalProperty.ExternalTaggedProperty != null)
            {
                externalProperty.ExternalTaggedProperty.RemoveListener(listener);
            }
            else
            {
                localProperty.RemoveListener(listener);
            }
        }
        public void AddListener(UnityAction<ContainedType> listener)
        {
            if (externalProperty.ExternalTaggedProperty != null)
            {
                externalProperty.ExternalTaggedProperty.AddListener(listener);
            }
            else
            {
                localProperty.AddListener(listener);
            }
        }
        public void RemoveListener(UnityAction<ContainedType> listener)
        {
            if (externalProperty.ExternalTaggedProperty != null)
            {
                externalProperty.ExternalTaggedProperty.RemoveListener(listener);
            }
            else
            {
                localProperty.RemoveListener(listener);
            }
        }
    }
}