using UnityEngine;

namespace HyperGnosys.Core
{
    [CreateAssetMenu(fileName = "NullObjectPatternReferences", menuName = "HyperGnosys/NullObjectPatternReferences")]
    public class NullObjectPatternReferences : ScriptableObject
    {
        [SerializeField] public GameObject noGameObject;

        private static NullObjectPatternReferences instance;
        public static GameObject NoGameObject;

        private void OnValidate()
        {
            instance = this;
            NoGameObject = noGameObject;
        }
    }
}