using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public interface IObservableProperty<ContainedType>
    {
        ContainedType Value { get; set; }
        void AddListener(UnityAction<ContainedType> listener);
        void RemoveListener(UnityAction<ContainedType> listener);
    }
}