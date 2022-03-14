using HyperGnosys.Core;
using UnityEngine;
public class TaggedPropertyBehaviour : MonoBehaviour
{
    [SerializeField] private ExternalizableLabeledProperty<string> sampleString;
    [SerializeField] private ExternalizableLabeledProperty<float> sampleLocalFloat;
    [SerializeField] private ExternalizableLabeledProperty<float> sampleComponentFloat;
    [SerializeField] private ExternalizableLabeledProperty<float> sampleScriptableFloat;

    private void Awake()
    {
        Debug.Log("String Value: " + sampleString.Label + " " + sampleString.Value);
        Debug.Log("Local Float Value: " + sampleLocalFloat.Label + " " + sampleLocalFloat.Value);
        Debug.Log("Component Value: " + sampleComponentFloat.Label + " " + sampleComponentFloat.Value);
        Debug.Log("Scriptable Value: " + sampleScriptableFloat.Label + " " + sampleScriptableFloat.Value);
    }
}