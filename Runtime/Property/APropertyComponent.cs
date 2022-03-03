using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    /// <summary>
    /// El chiste de la MonoProperty es contener una implementacion de una property
    /// en un MonoBehaviour para que que pueda ser referenciada desde varios lugares. 
    /// Por ejemplo la Vida de un jugador
    /// </summary>
    /// <typeparam name="ContainedType">
    /// Se necesita para verificar que el tipo de dato contenido es una Property
    /// y que se puedan hacer cosas como suscribirse al evento que tienen todas las AProperties
    /// </typeparam>
    public abstract class APropertyComponent<ContainedType>
        : MonoBehaviour, IObservableProperty<ContainedType>
    {
        [SerializeField] private bool debugging = false;
        [Space]
        [Tooltip("This marks the Property as Constant, which means that it will reject reassignations to it." +
            "\n\nProperties marked Constant send a warning message when there's an attempt to reassign them.")]
        [SerializeField] private bool isConstant = false;
        [SerializeField] private ContainedType property;
        [SerializeField] private GameEvent<ContainedType> onPropertyValueChanged = new GameEvent<ContainedType>();

        public ContainedType Value
        {
            get => property;
            set
            {
                if (isConstant)
                {
                    HGDebug.Log("Se intento asignar un valor a una variable constante", this, debugging);
                    return;
                }
                else
                {
                    this.property = value;
                    onPropertyValueChanged?.Raise(value);
                }
            }
        }
        public void AddListener(IGameEventListener<ContainedType> listener)
        {
            onPropertyValueChanged.AddListener(listener);
        }
        public void RemoveListener(IGameEventListener<ContainedType> listener)
        {
            onPropertyValueChanged.RemoveListener(listener);
        }
        public void AddListener(UnityAction<ContainedType> listener)
        {
            onPropertyValueChanged.AddListener(listener);
        }
        public void RemoveListener(UnityAction<ContainedType> listener)
        {
            onPropertyValueChanged.RemoveListener(listener);
        }
    }
}