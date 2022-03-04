using System;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class TaggedProperty<ContainedType> : ObservableProperty<ContainedType>
    {
        [SerializeField] private PropertyTag tag;

        public PropertyTag Tag { get => tag; }
    }
}