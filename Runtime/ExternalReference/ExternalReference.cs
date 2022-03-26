using UnityEngine;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class ExternalReference<TypeToReference> : ISerializationCallbackReceiver where TypeToReference : class
    {
        [SerializeField] private Object referenceObject;

        public void OnBeforeSerialize()
        {
            if (referenceObject == null) return;

            if (referenceObject is GameObject)
            {
                GameObject gameObject = (GameObject)referenceObject;
                referenceObject = gameObject.GetComponent(typeof(TypeToReference));
                ExternalReferenceUtilities.NotifyIfExternalReferenceIsNull<TypeToReference>(referenceObject);
                return;
            }

            if (!(referenceObject is TypeToReference))
            {
                referenceObject = null;
                Debug.LogWarning($"Your ScriptableObject must implement {typeof(TypeToReference)}");
            }
        }

        public void OnAfterDeserialize()
        {
        }

        public TypeToReference Reference
        {
            get
            {
                if (referenceObject == null || !(referenceObject is TypeToReference)) return null;
                return (TypeToReference)(object)referenceObject;
            }
        }

        public Object ReferenceObject
        {
            get => referenceObject;
            private set
            {
                if (value == null)
                {
                    referenceObject = null;
                }
                if (value is TypeToReference)
                {
                    referenceObject = value;
                }
                else
                {
                    referenceObject = null;
                    Debug.LogWarning($"You should set an Object that implements {typeof(TypeToReference).FullName}");
                }
            }
        }
    }
}