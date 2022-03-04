using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class ExternalizableObservableProperty<ContainedType> : IObservableProperty<ContainedType>
    {
        [SerializeField] private bool debugExternalizableProperty = false;
        [SerializeField] private ObservableProperty<ContainedType> localProperty;
        [Space]
        [Tooltip("Only assign this if this property should be contained in an external object, otherwise just set the localProperty value." +
            "\n\nIf the externalProperty is set, the localProperty will be ignored, including the localPropertyReassigned Event. " +
            "\n\nThe external object should be a Monobehaviour or a ScriptableObject. " +
            "\nWhichever it is, it has to implement PropertyInterface. There are many premade components in Attributes.")]
        [SerializeField] private ExternalReference<IObservableProperty<ContainedType>> externalProperty 
            = new ExternalReference<IObservableProperty<ContainedType>>();


        public virtual ContainedType Value
        {
            get
            {
                if (externalProperty.Reference != null)
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
                if (externalProperty.Reference != null)
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
            if (externalProperty.Reference != null)
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
            if (externalProperty.Reference != null)
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
            if (externalProperty.Reference != null)
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
            if (externalProperty.Reference != null)
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