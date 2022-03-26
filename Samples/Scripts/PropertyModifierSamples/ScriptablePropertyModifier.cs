using HyperGnosys.Core;
using UnityEngine;

[CreateAssetMenu()]
public class ScriptablePropertyModifier : ScriptableObject
{
    [SerializeField] private PropertyModifier modifier;
    public void DecreaseProperty()
    {
        modifier.DecreaseProperty();
    }
    public void IncreaseProperty()
    {
        modifier.IncreaseProperty();
    }
}
