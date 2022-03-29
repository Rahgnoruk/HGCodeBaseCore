using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public abstract class AScriptableObservableProperty<ContainedType> : ScriptableObject, IObservableProperty<ContainedType>
    {
        [SerializeField] private bool debugging = false;
        [SerializeField] private ObservableProperty<ContainedType> globalProperty;

        public ContainedType Value
        {
            get => globalProperty.Value;
            set => globalProperty.Value = value;
        }
        public void AddListener(UnityAction<ContainedType> listener)
        {
            globalProperty.AddListener(listener);
        }
        public void RemoveListener(UnityAction<ContainedType> listener)
        {
            globalProperty.RemoveListener(listener);
        }
    }
}