using HyperGnosys.Core;
using UnityEngine;

public class ModifyHealth : MonoBehaviour
{
    [SerializeField] private float damageAmount = 10;
    [SerializeField] private float healAmount = 10;

    [SerializeField] private ExternalizableLabeledProperty<float> health;
    public void DealDamage()
    {
        health.Value -= damageAmount;
    }
    public void HealDamage()
    {
        health.Value += healAmount;
    }
}
