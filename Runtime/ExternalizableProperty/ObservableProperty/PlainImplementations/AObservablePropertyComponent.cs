using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public abstract class AObservablePropertyComponent<ContainedType> : MonoBehaviour, IObservableProperty<ContainedType>
    {
        [SerializeField] private bool debugging = false;
        [Space]
        [SerializeField] private ObservableProperty<ContainedType> property;

        public ContainedType Value
        {
            get => property.Value;
            set => property.Value = value;
        }
        public void AddListener(UnityAction<ContainedType> listener)
        {
            property.AddListener(listener);
        }
        public void RemoveListener(UnityAction<ContainedType> listener)
        {
            property.RemoveListener(listener);
        }
    }
}