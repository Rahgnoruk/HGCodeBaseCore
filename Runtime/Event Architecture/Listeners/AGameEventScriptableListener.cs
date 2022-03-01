using UnityEngine;

namespace HyperGnosys.Core
{
    public abstract class AGameEventScriptableListener<PassedObjectType> 
        : ScriptableObject, IGameEventListener<PassedObjectType>
    {
        [SerializeField] private GameEventListener<PassedObjectType> eventListener 
            = new GameEventListener<PassedObjectType>();

        public virtual void OnEventRaised(PassedObjectType item)
        {
            if (eventListener.Responses == null)
            {
                HGDebug.LogWarning("El listener en " + name
                    + "esta escuchando pero " +
                    "no tiene respuesta asignada", eventListener.Debugging);
            }
            eventListener.OnEventRaised(item);
        }
        private void Awake()
        {
            if (eventListener.GameEvent == null)
            {
                HGDebug.LogWarning("No se ha asigando un evento al Listener en " + name, eventListener.Debugging);
                return;
            }
            eventListener.GameEvent.AddListener(this);
        }
        private void OnDestroy()
        {
            if (eventListener.GameEvent != null)
            {
                HGDebug.LogWarning("No se ha asigando un evento al Listener" + name, eventListener.Debugging);
                return;
            }
            eventListener.GameEvent.RemoveListener(this);
        }
    }
}