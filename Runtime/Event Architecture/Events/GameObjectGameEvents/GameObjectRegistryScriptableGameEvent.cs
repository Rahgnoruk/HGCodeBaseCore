using UnityEngine;

namespace HyperGnosys.Core
{
    [CreateAssetMenu(fileName = "New GameObject Registry Scriptable Event", 
        menuName = "HyperGnosys/Events/GameObject Registry Scriptable Event")]
    public class GameObjectRegistryScriptableGameEvent: AScriptableEvent<ListWrapper<GameObject>>
    {
    }
}