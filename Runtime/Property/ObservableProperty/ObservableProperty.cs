using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class ObservableProperty<ContainedType> : IObservableProperty<ContainedType>
    {
        [SerializeField] private ContainedType localProperty;
        [SerializeField] private GameEvent<ContainedType> onLocalPropertyReassigned = new GameEvent<ContainedType>();
        public ContainedType Value
        {
            get => localProperty;
            set
            {
                this.localProperty = value;
                onLocalPropertyReassigned?.Raise(value);
            }
        }

        public void AddListener(IGameEventListener<ContainedType> listener)
        {
            onLocalPropertyReassigned.AddListener(listener);
            listener.OnEventRaised(localProperty);
        }
        public void RemoveListener(IGameEventListener<ContainedType> listener)
        {
            onLocalPropertyReassigned.RemoveListener(listener);
        }
        public void AddListener(UnityAction<ContainedType> listener)
        {
            onLocalPropertyReassigned.AddListener(listener);
            listener(localProperty);
        }
        public void RemoveListener(UnityAction<ContainedType> listener)
        {
            onLocalPropertyReassigned.RemoveListener(listener);
        }
    }
}