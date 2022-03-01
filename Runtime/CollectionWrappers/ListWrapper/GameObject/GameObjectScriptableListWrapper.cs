using UnityEngine;

namespace HyperGnosys.Core
{
    [CreateAssetMenu(fileName = "New GameObject List Wrapper",
        menuName = "HyperGnosys/Registries/GameObject List Wrapper")]
    public class GameObjectScriptableListWrapper : AScriptableListWrapper<GameObject>
    {
    }
}