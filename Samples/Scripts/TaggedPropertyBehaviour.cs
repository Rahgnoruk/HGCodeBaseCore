using HyperGnosys.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaggedPropertyBehaviour : MonoBehaviour
{
    [SerializeField] private ExternalizableTaggedProperty<float> someLocalFloatVariable;
    [SerializeField] private ExternalizableTaggedProperty<float> someGlobalFloatVariable;
}
