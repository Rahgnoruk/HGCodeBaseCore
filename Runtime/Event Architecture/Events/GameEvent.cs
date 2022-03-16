using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace HyperGnosys.Core
{
    [Serializable]
    public class GameEvent<T> : IGameEvent<T>
    {
        [SerializeField] private bool debugGameEvent = false;
        [Space]
        [SerializeField] private UnityEvent<T> onEventRaised = new UnityEvent<T>();

        private readonly List<IGameEventListener<T>> listeners = new List<IGameEventListener<T>>();

        public virtual void Raise(T item)
        {
            HGDebug.Log("Game Event Raised with new value: " + item.ToString(), debugGameEvent);
            onEventRaised?.Invoke(item);
            ///Va desde el ultimo al primero en caso de que 
            ///como parte de la respuesta el listener se remueva
            ///de la lista. Asi no tienes que revisar si se removio
            ///para recorrer el contador
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(item);
            } 
        }

        public void AddListener(IGameEventListener<T> listener)
        {
            if (!listeners.Contains(listener))
            {
                listeners.Add(listener);
            }
        }
        public void RemoveListener(IGameEventListener<T> listener)
        {
            if (listeners.Contains(listener))
            {
                listeners.Remove(listener);
            }
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