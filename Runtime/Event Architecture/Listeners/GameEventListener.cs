using System;
using UnityEngine;
using UnityEngine.Events;
namespace HyperGnosys.Core
{
    [Serializable]
    public class GameEventListener<PassedObjectType> : IGameEventListener<PassedObjectType>
    {
        [SerializeField] private bool debugging = false;
        [SerializeField] private ExternalReference<IGameEvent<PassedObjectType>> gameEvent
            = new ExternalReference<IGameEvent<PassedObjectType>>();

        [SerializeField] private UnityEvent<PassedObjectType> responses = new UnityEvent<PassedObjectType>();

        public virtual void OnEventRaised(PassedObjectType item)
        {
            HGDebug.Log($"{gameEvent.ReferenceObject.name} raise an event", debugging);
            responses.Invoke(item);
        }

        public IGameEvent<PassedObjectType> GameEvent { get => gameEvent.Reference ;}
        public bool Debugging { get => debugging; set => debugging = value; }
        public UnityEvent<PassedObjectType> Responses { get => responses; set => responses = value; }
    }
}