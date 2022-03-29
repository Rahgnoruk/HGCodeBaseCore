using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public abstract class AEventComponent<T> : MonoBehaviour, IGameEvent<T>
    {
        [SerializeField] private GameEvent<T> gameEvent = new GameEvent<T>();

        public virtual void Raise(T item)
        {
            HGDebug.Log($"Raising event in {transform.name}", gameEvent.Debugging);
            gameEvent.Raise(item);
        }
        public void AddListener(UnityAction<T> listener)
        {
            gameEvent.AddListener(listener);
        }
        public void RemoveListener(UnityAction<T> listener)
        {
            gameEvent.RemoveListener(listener);
        }
        protected GameEvent<T> GameEvent { get => gameEvent; set => gameEvent = value; }
    }
}