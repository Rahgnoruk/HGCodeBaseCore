using HyperGnosys.Core;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FloatPropertyLabel : MonoBehaviour
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
        BuildPropertyText(property.Value);
        property.AddListener(BuildPropertyText);
    }
    private void BuildPropertyText(float newValue)
    {
        StringBuilder builder = new StringBuilder();
        builder.Append(property.Label);
        builder.Append(": ");
        builder.Append(newValue);
        text.text = builder.ToString();
    }
    private void OnDisable()
    {
        property.RemoveListener(BuildPropertyText);
    }
}
