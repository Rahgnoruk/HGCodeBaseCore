using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class ObservableProperty<ContainedType> : IObservableProperty<ContainedType>
    {
        [SerializeField] private ContainedType value;
        [SerializeField] private GameEvent<ContainedType> onValueChanged = new GameEvent<ContainedType>();
        public ContainedType Value
        {
            get => value;
            set
            {
                this.value = value;
                onValueChanged?.Raise(value);
            }
        }

        public void AddListener(IGameEventListener<ContainedType> listener)
        {
            onValueChanged.AddListener(listener);
        }
        public void RemoveListener(IGameEventListener<ContainedType> listener)
        {
            onValueChanged.RemoveListener(listener);
        }
        public void AddListener(UnityAction<ContainedType> listener)
        {
            onValueChanged.AddListener(listener);
        }
        public void RemoveListener(UnityAction<ContainedType> listener)
        {
            onValueChanged.RemoveListener(listener);
        }
    }
}