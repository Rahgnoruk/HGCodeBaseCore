using UnityEngine;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class TaggedProperty<ContainedType>
    {
        [SerializeField] private PropertyTag tag;
        [SerializeField] private ObservableProperty<ContainedType> property;

        public PropertyTag Tag { get => tag; }
        public ObservableProperty<ContainedType> Property { get => property; set => property = value; }
    }
}