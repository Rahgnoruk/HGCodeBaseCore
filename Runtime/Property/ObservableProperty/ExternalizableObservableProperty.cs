using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class ExternalizableObservableProperty<ContainedType> : IObservableProperty<ContainedType>
    {
        [SerializeField] private bool debugExternalizableProperty = false;
        [SerializeField] private bool useExternalProperty = false;
        [SerializeField] private ObservableProperty<ContainedType> localProperty;
        [SerializeField] private ExternalReference<IObservableProperty<ContainedType>> externalProperty 
            = new ExternalReference<IObservableProperty<ContainedType>>();


        public virtual ContainedType Value
        {
            get
            {
                if (useExternalProperty)
                {
                    HGDebug.Log($"Accesing Property in {externalProperty.ReferenceObject.name}", debugExternalizableProperty);
                    return externalProperty.Reference.Value;
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
                    externalProperty.Reference.Value = value;
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
                externalProperty.Reference.AddListener(listener);
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
                externalProperty.Reference.RemoveListener(listener);
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
                externalProperty.Reference.AddListener(listener);
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
                externalProperty.Reference.RemoveListener(listener);
            }
            else
            {
                localProperty.RemoveListener(listener);
            }
        }
    }
}