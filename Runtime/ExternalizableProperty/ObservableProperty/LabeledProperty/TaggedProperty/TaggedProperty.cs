using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class TaggedProperty<ContainedType> : IObservableProperty<ContainedType>
    {
        [SerializeField] private PropertyTag tag;
        [SerializeField] private ObservableProperty<ContainedType> property;

        public PropertyTag Tag { get => tag; }
        public ContainedType Value { get => property.Value; set => property.Value = value; }

        public void AddListener(IGameEventListener<ContainedType> listener)
        {
            property.AddListener(listener);
        }
        public void RemoveListener(IGameEventListener<ContainedType> listener)
        {
            property.RemoveListener(listener);
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