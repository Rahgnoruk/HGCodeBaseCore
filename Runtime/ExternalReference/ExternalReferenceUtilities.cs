using UnityEngine;

namespace HyperGnosys.Core
{
    public static class ExternalReferenceUtilities
    {
        public static bool NotifyIfExternalReferenceIsNull<TypeToReference>(Object reference)
        {
            if (reference == null)
            {
                Debug.LogWarning($"Your GameObject must have a component that implements {typeof(TypeToReference)}");
                return true;
            }
            return false;
        }
    }
}