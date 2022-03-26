using UnityEngine;

public class PropertyModifierComponent : MonoBehaviour
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
