using UnityEngine;

namespace HyperGnosys.Core
{
    [CreateAssetMenu(fileName = "New GameObject Observable List",
        menuName = "HyperGnosys/Externalizable Properties/Lists/Observable GameObject List")]
    public class GameObjectScriptableObservableList : AScriptableObservableList<GameObject>
    {
    }
}