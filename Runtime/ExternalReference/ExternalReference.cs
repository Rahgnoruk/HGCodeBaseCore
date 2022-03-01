using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace HyperGnosys.Core
{
    [Serializable]
    public class ExternalReference<TypeToReference> : ISerializationCallbackReceiver where TypeToReference : class
    {
        [SerializeField] private Object referenceObject;

        public void OnBeforeSerialize()
        {
            if (referenceObject == null)
            {
                return;
            }

            if (referenceObject is GameObject)
            {
                GameObject gameObject = (GameObject)referenceObject;
                referenceObject = gameObject.GetComponent(typeof(TypeToReference));

                if (referenceObject == null)
                {
                    Debug.LogWarning("You must assign a gameObject that has at least one component of type " +
                        $"{typeof(TypeToReference).FullName}");
                    return;
                }
            }

            if (!(referenceObject is TypeToReference))
            {
                referenceObject = null;
                Debug.LogWarning($"You must assign an Object that implements {typeof(TypeToReference).FullName}");
            }
        }

        public void OnAfterDeserialize()
        {
        }

        public TypeToReference Reference
        {
            get
            {
                return referenceObject != null ? (TypeToReference)(object)referenceObject : null;
            }
        }

        public Object ReferenceObject
        {
            get => referenceObject;
            private set
            {
                ///Significa que se acaba de asignar Null a la variable
                if (value == null)
                {
                    referenceObject = null;
                }
                ///Se asigno un objeto del tipo correcto
                if (value is TypeToReference)
                {
                    referenceObject = value;
                }
                ///Significa que se asigno un objeto pero no es 
                ///del tipo correcto
                else
                {
                    referenceObject = null;
                    Debug.LogWarning($"You should set an Object that implements {typeof(TypeToReference).FullName}");
                }
            }
        }
    }
}