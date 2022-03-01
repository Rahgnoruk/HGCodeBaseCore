using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public abstract class AScriptableEvent<T> : ScriptableObject, IGameEvent<T>
    {
        [SerializeField] private GameEvent<T> gameEvent = new GameEvent<T>();
        public UnityEvent<T> onEventRaised => gameEvent.OnEventRaised;
        public virtual void Raise(T item)
        {
            HGDebug.Log($"Raising event in {this.name}", gameEvent.Debugging);
            gameEvent.Raise(item);
        }

        public void AddListener(IGameEventListener<T> listener)
        {
            gameEvent.AddListener(listener);
        }
        public void RemoveListener(IGameEventListener<T> listener)
        {
            gameEvent.RemoveListener(listener);
        }
        public void AddListener(UnityAction<T> listener)
        {
            gameEvent.AddListener(listener);
        }
        public void RemoveListener(UnityAction<T> listener)
        {
            gameEvent.RemoveListener(listener);
        }
    }
}