using UnityEngine;
using UnityEngine.Events;
namespace HyperGnosys.Core
{
    [System.Serializable]
    public class GameEvent<T> : IGameEvent<T>
    {
        [SerializeField] private bool debugGameEvent = false;
        [Space]
        [SerializeField] private UnityEvent<T> onEventRaised = new UnityEvent<T>();
        public virtual void Raise(T item)
        {
            HGDebug.Log("Game Event Raised with new value: " + item.ToString(), debugGameEvent);
            onEventRaised?.Invoke(item);
        }
        public void AddListener(UnityAction<T> listener)
        {
            onEventRaised.AddListener(listener);
        }
        public void RemoveListener(UnityAction<T> listener)
        {
            onEventRaised.RemoveListener(listener);
        }
        public bool Debugging { get => debugGameEvent; set => debugGameEvent = value; }
        public UnityEvent<T> OnEventRaised { get => onEventRaised; set => onEventRaised = value; }
    }
}