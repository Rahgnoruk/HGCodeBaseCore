using HyperGnosys.Core;
using UnityEngine;
public class SampleBehaviour : MonoBehaviour
{
    [SerializeField] private ExternalizableProperty<float> someLocalFloatVariable;
    [SerializeField] private ExternalizableProperty<float> someGlobalFloatVariable;
}
