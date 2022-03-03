using System;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class Attribute<AttributeType> : Property<AttributeType>
    {
        [SerializeField] private AttributeTag tag;

        public AttributeTag Tag { get => tag; set => tag = value; }
    }
}