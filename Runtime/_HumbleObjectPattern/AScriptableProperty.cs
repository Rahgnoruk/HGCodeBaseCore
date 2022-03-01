using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    /// <summary>
    /// Nota de recordatorio: Si quieres que un monobehaviour pueda escuchar el cambio de una Variable Global, crea 
    /// ScriptableEvents y conectalos con onGlobalPropertyReassigned.
    /// </summary>
    /// <typeparam name="ContainedType"></typeparam>
    public abstract class AScriptableProperty<ContainedType> : ScriptableObject, PropertyInterface<ContainedType>
    {
        [SerializeField] private bool debugging = false;
        [Space]
        [Tooltip("This marks the Property as Constant, which means that it will reject reassignations to it." +
            "\n\nProperties marked Constant send a warning message when there's an attempt to reassign them.")]
        [SerializeField] private bool isConstant = false;
        [SerializeField] private ContainedType globalProperty;
        [SerializeField] private GameEvent<ContainedType> onGlobalPropertyValueChanged = new GameEvent<ContainedType>();

        public ContainedType Value
        {
            get => globalProperty;
            set
            {
                if (isConstant)
                {
                    HGDebug.Log("Se intento asignar un valor a una variable constante", this, debugging);
                    return;
                }
                else
                {
                    this.globalProperty = value;
                    onGlobalPropertyValueChanged?.Raise(value);
                }
            }
        }
        public void AddListener(IGameEventListener<ContainedType> listener)
        {
            onGlobalPropertyValueChanged.AddListener(listener);
        }
        public void RemoveListener(IGameEventListener<ContainedType> listener)
        {
            onGlobalPropertyValueChanged.RemoveListener(listener);
        }
        public void AddListener(UnityAction<ContainedType> listener)
        {
            onGlobalPropertyValueChanged.AddListener(listener);
        }
        public void RemoveListener(UnityAction<ContainedType> listener)
        {
            onGlobalPropertyValueChanged.RemoveListener(listener);
        }
    }
}