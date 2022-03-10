using HyperGnosys.Core;
using UnityEngine;
public class ObservablePropertyBehaviour : MonoBehaviour
{
    [SerializeField] private ExternalizableObservableProperty<float> sampleLocalFloat;
    [SerializeField] private ExternalizableObservableProperty<float> sampleComponentFloat;
    [SerializeField] private ExternalizableObservableProperty<float> sampleScriptableFloat;
}
