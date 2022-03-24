using HyperGnosys.Core;
using UnityEngine;
public class ObservablePropertyBehaviour : MonoBehaviour
{
    [SerializeField] private ExternalizableObservableProperty<float> sampleLocalFloat;
    [SerializeField] private ExternalizableObservableProperty<float> sampleComponentFloat;
    [SerializeField] private ExternalizableObservableProperty<float> sampleScriptableFloat;
    [SerializeField] private ComponentReference<IObservableProperty<float>> observableFloat;
    private void Awake()
    {
        Debug.Log("Local Float Value: " + sampleLocalFloat.Value);
        Debug.Log("Component Value: " + sampleComponentFloat.Value);
        Debug.Log("Scriptable Value: " + sampleScriptableFloat.Value);
        Debug.Log("String Value: " + observableFloat.Reference.Value);
    }
}