using HyperGnosys.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PropertyModifier
{
    [SerializeField] private float reduceAmount = 10;
    [SerializeField] private float addAmount = 10;

    [SerializeField] private ExternalizableLabeledProperty<float> property;
    public void DecreaseProperty()
    {
        property.Value -= reduceAmount;
    }
    public void IncreaseProperty()
    {
        property.Value += addAmount;
    }
}
