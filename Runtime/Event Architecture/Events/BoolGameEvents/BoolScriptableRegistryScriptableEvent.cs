using UnityEngine;

namespace HyperGnosys.Core
{
    [CreateAssetMenu(fileName = "New Scriptable Bool Registry Scriptable Event",
        menuName = "HyperGnosys/Events/Scriptable Bool Registry Scriptable Event")]
    public class BoolScriptableRegistryScriptableEvent : AScriptableEvent<ListWrapper<bool>>
    {
    }
}