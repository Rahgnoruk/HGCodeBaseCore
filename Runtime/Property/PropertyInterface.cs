using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public interface PropertyInterface<ContainedType>
    {
        ContainedType Value { get; set; }
        void AddListener(IGameEventListener<ContainedType> listener);
        void RemoveListener(IGameEventListener<ContainedType> listener);
        void AddListener(UnityAction<ContainedType> listener);
        void RemoveListener(UnityAction<ContainedType> listener);
    }
}