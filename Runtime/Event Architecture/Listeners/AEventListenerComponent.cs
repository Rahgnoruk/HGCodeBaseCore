using UnityEngine;

namespace HyperGnosys.Core
{
    /// <summary>
    /// Version Monobehaviour del Event Listener.
    /// Puede escuchar un evento de un Scriptable Object o de un 
    /// Monobejaviour
    /// </summary>
    /// <typeparam name="PassedObjectType"></typeparam>
    /// <typeparam name="EventReference"></typeparam>
    /// <typeparam name="UnityEvent"></typeparam>
    public abstract class AEventListenerComponent<PassedObjectType> : MonoBehaviour, IGameEventListener<PassedObjectType>
    {
        [SerializeField] private GameEventListener<PassedObjectType> eventListener 
            = new GameEventListener<PassedObjectType>();

        public virtual void OnEventRaised(PassedObjectType item)
        {
            HGDebug.Log($"Event Raised on {transform.name}", eventListener.Debugging);
            if (eventListener.Responses == null)
            {
                HGDebug.LogWarning("El listener en " + transform.name
                    + "esta escuchando pero " +
                    "no tiene respuesta asignada", eventListener.Debugging);
            }
            eventListener.OnEventRaised(item);
        }
        private void OnEnable()
        {
            if (eventListener.GameEvent == null)
            {
                HGDebug.LogWarning("No se ha asigando un evento al Listener en " + transform.name, eventListener.Debugging);
                return;
            }
            eventListener.GameEvent.AddListener(this);
        }
        private void OnDisable()
        {
            if (eventListener.GameEvent == null)
            {
                HGDebug.LogWarning("No se ha asigando un evento al Listener " + transform.name 
                    + " de " + transform.root.name, eventListener.Debugging);
                return;
            }
            ///Esto puede mandar NullReferenceException si se pone el Listener en un UI element
            ///que esta escuchando un GameObject. Ocurre porque el GameObject es deshabilitado 
            ///al salir de play mode antes de que se haga el removelistener. Para corregirlo
            ///puedes poner el listener en un GameObject y luego poner el GameObject en donde
            ///estaba el UIElement. 
            eventListener.GameEvent.RemoveListener(this);
        }
        public GameEventListener<PassedObjectType> EventListener { get => eventListener; set => eventListener = value; }
    }
}