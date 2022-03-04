using HyperGnosys.Core;
using UnityEngine;
public class ObservablePropertyBehaviour : MonoBehaviour
{
    [SerializeField] private ExternalizableObservableProperty<float> someLocalFloatVariable;
    [SerializeField] private ExternalizableObservableProperty<float> someGlobalFloatVariable;
}
