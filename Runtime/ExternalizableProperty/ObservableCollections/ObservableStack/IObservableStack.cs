using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public interface IObservableStack<ContainedType>
    {
        int Count { get; }
        void Push();
        void Pop();
        void Peek();
        void Clear();
        void AddOnItemPushedListener(UnityAction<ContainedType> listener);
        void AddOnItemPoppedListener(UnityAction<ContainedType> listener);
        void AddOnStackClearedListener(UnityAction listener);
        void RemoveOnItemPushedListener(UnityAction<ContainedType> listener);
        void RemoveOnItemPoppedListener(UnityAction<ContainedType> listener);
        void RemoveOnStackClearedListener(UnityAction listener);
    }
}