using UnityEngine;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class ComponentReference<TypeToReference> : ISerializationCallbackReceiver where TypeToReference : class
    {
        [SerializeField] private GameObject referenceObject;
        [SerializeField, HideInInspector] private Component referenceComponent;
        public void OnBeforeSerialize()
        {
            if (referenceObject == null) return;
            referenceComponent = referenceObject.GetComponent(typeof(TypeToReference));
            if (ExternalReferenceUtilities.NotifyIfExternalReferenceIsNull<TypeToReference>(referenceComponent))
            {
                referenceObject = null;
            }
        }
        public void OnAfterDeserialize()
        {
        }
        public TypeToReference Reference
        {
            get
            {
                if (referenceObject == null || !(referenceComponent is TypeToReference)) return null;
                return (TypeToReference)(object)referenceComponent;
            }
        }
    }
}