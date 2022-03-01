using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public interface IGameEvent<ReturnType>
    {
        void Raise(ReturnType item);
        void AddListener(IGameEventListener<ReturnType> listener);
        void RemoveListener(IGameEventListener<ReturnType> listener);
        void AddListener(UnityAction<ReturnType> listener);
        void RemoveListener(UnityAction<ReturnType> listener);
    }
}