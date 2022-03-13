using HyperGnosys.Core;
using UnityEngine;
public class TaggedPropertyBehaviour : MonoBehaviour
{
    [SerializeField] private ExternalizableTaggedProperty<string> sampleString;
    [SerializeField] private ExternalizableTaggedProperty<float> sampleLocalFloat;
    [SerializeField] private ExternalizableTaggedProperty<float> sampleComponentFloat;
    [SerializeField] private ExternalizableTaggedProperty<float> sampleScriptableFloat;
}