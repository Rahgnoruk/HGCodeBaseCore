using HyperGnosys.Core;
using UnityEngine;
public class TaggedPropertyBehaviour : MonoBehaviour
{
    [SerializeField] private ExternalizableTaggedProperty<string> sampleString;
    [SerializeField] private ExternalizableTaggedProperty<float> sampleLocalFloat;
    [SerializeField] private ExternalizableTaggedProperty<float> sampleComponentFloat;
    [SerializeField] private ExternalizableTaggedProperty<float> sampleScriptableFloat;

    private void Awake()
    {
        Debug.Log("String Value: " + sampleString.Value);
        Debug.Log("Local Float Value: " + sampleLocalFloat.Value);
        Debug.Log("Component Value: " + sampleComponentFloat.Value);
        Debug.Log("Scriptable Value: " + sampleScriptableFloat.Value);
    }
}