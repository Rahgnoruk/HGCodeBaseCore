using HyperGnosys.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Slider))]
public class PropertyFillSlider : MonoBehaviour
{
    [SerializeField] private Slider fillSlider;
    [SerializeField] private ExternalizableLabeledProperty<float> currentPropertyValue;
    [SerializeField] private ExternalizableLabeledProperty<float> maxPropertyValue;

    private void Reset()
    {
        fillSlider = GetComponent<Slider>();
    }
    private void Awake()
    {
        Reset();
        fillSlider.maxValue = maxPropertyValue.Value;
        fillSlider.value = currentPropertyValue.Value;

        currentPropertyValue.AddListener(OnCurrentValueChanged);
        maxPropertyValue.AddListener(OnMaxValueChanged);
    }
    private void OnCurrentValueChanged(float value)
    {
        fillSlider.value = value;
    }
    private void OnMaxValueChanged(float value)
    {
        fillSlider.maxValue = value;
    }
    private void OnDisable()
    {
        currentPropertyValue.RemoveListener(OnCurrentValueChanged);
        maxPropertyValue.RemoveListener(OnMaxValueChanged);
    }
}
