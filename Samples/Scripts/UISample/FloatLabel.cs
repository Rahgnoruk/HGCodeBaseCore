using HyperGnosys.Core;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(FloatLabel))]
public class FloatLabel : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private ExternalizableLabeledProperty<float> property;

    private void Reset()
    {
        text = GetComponent<Text>();
    }
    private void Awake()
    {
        Reset();
        text.text = property.Label;
    }
}
