using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public interface IObservableQueue<ContainedType>
    {
        int Count { get; }
        void Enqueue();
        void Dequeue();
        void Peek();
        void Clear();
        void AddOnItemEnqueuedListener(UnityAction<ContainedType> listener);
        void AddOnItemDequeuedListener(UnityAction<ContainedType> listener);
        void AddOnStackClearedListener(UnityAction listener);
        void RemoveOnItemEnqueuedListener(UnityAction<ContainedType> listener);
        void RemoveOnItemDequeuedListener(UnityAction<ContainedType> listener);
        void RemoveOnStackClearedListener(UnityAction listener);
    }
}