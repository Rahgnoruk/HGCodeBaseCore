using System;
using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    /// <summary>
    /// La property es un Plain Old C# Object que puedes poner en un Scriptable Object
    /// o un Monobehaviour por igual, y que tambien puede lanzar eventos desde un 
    /// ScriptableObject o un Monobehaviour.
    /// </summary>
    /// <typeparam name="ContainedType"></typeparam>
    /// <typeparam name="AScriptablePropertyImplementation"></typeparam>
    /// <typeparam name="ContainedTypeEventReference"></typeparam>
    /// RECUERDA MARCAR SERIALIZABLES LAS CLASES QUE HEREDEN
    [Serializable]
    public class Property <ContainedType> : PropertyInterface<ContainedType>
    {

        [SerializeField] private bool debugging = false;
        [Space]
        [Tooltip("This marks the Property as Constant, which means that it will reject reassignations to it." +
            "\n\nProperties marked Constant send a warning message when there's an attempt to reassign them.")]
        [SerializeField] private bool isConstant = false;
        [Space]
        [SerializeField] private ContainedType localProperty;
        [Tooltip("This is an event that gets raised when the localProperty changes. It returns a value of the same Data Type as the Property itself." +
            "\n\nIf the externalProperty is assigned, this event is not used.")]
        [SerializeField]
        private GameEvent<ContainedType> onLocalPropertyReassigned = new GameEvent<ContainedType>();
        [Space]
        [Tooltip("Only assign this if this property should be contained in an external object, otherwise just set the localProperty value." +
            "\n\nIf the externalProperty is set, the localProperty will be ignored, including the localPropertyReassigned Event. " +
            "\n\nThe external object should be a Monobehaviour or a ScriptableObject. " +
            "\nWhichever it is, it has to implement PropertyInterface. There are many premade components in Attributes.")]
        [SerializeField] private ExternalReference<PropertyInterface<ContainedType>> externalProperty
            = new ExternalReference<PropertyInterface<ContainedType>>();
        

        public virtual ContainedType Value
        {
            get
            {
                if (externalProperty.Reference != null)
                {
                    HGDebug.Log($"Accesing Property in {externalProperty.ReferenceObject.name}", debugging);
                    return externalProperty.Reference.Value;
                }
                else
                {
                    return localProperty;
                }
            }
            set
            {
                if (isConstant)
                {
                    HGDebug.Log("Se intento asignar un valor a una variable constante", debugging);
                    return;
                }
                else
                {
                    if (externalProperty.Reference != null)
                    {
                        externalProperty.Reference.Value = value;
                    }
                    else
                    {
                        this.localProperty = value;
                        onLocalPropertyReassigned?.Raise(value);
                    }
                }
            }
        }
        public void AddListener(IGameEventListener<ContainedType> listener)
        {
            if (externalProperty.Reference != null)
            {
                externalProperty.Reference.AddListener(listener);
            }
            else
            {
                onLocalPropertyReassigned.AddListener(listener);
                listener.OnEventRaised(localProperty);
            }
        }
        public void RemoveListener(IGameEventListener<ContainedType> listener)
        {
            if (externalProperty.Reference != null)
            {
                externalProperty.Reference.RemoveListener(listener);
            }
            else
            {
                onLocalPropertyReassigned.RemoveListener(listener);
            }
        }
        public void AddListener(UnityAction<ContainedType> listener)
        {
            if (externalProperty.Reference != null)
            {
                externalProperty.Reference.AddListener(listener);
            }
            else
            {
                onLocalPropertyReassigned.AddListener(listener);
                listener(localProperty);
            }
        }
        public void RemoveListener(UnityAction<ContainedType> listener)
        {
            if (externalProperty.Reference != null)
            {
                externalProperty.Reference.RemoveListener(listener);
            }
            else
            {
                onLocalPropertyReassigned.RemoveListener(listener);
            }
        }
        /// <summary>
        /// Nota para no volver a olvidar que si hay casos en que se puede asignar la variable de constante.
        /// Puede ser para un valor que se quiere volver inalterable por un tiempo, o para una Property que 
        /// se crea en Runtime
        /// </summary>
        public bool IsConstant { get => isConstant; set => isConstant = value; }
        protected bool Debugging { get => debugging; set => debugging = value; }
    }
}