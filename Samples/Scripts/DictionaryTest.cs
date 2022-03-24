using HyperGnosys.Core;
using UnityEngine;

public class DictionaryTest : MonoBehaviour
{
    [SerializeField] private SerializableDictionary<float, string> test;

    private void Start()
    {
        Debug.Log($"Serializable Dic value: {test[1]} {test[2]} {test[3]}");
    }
}