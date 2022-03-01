using System.Collections.Generic;

namespace HyperGnosys.Core
{
    public class HashSetProperty<HashSetItemVariableType>: Property<HashSetWrapper<HashSetItemVariableType>>
    {
        public HashSetWrapper<HashSetItemVariableType> HashSetWrapper
        {
            ///Value ya hace la evaluacion de si debe usar ScriptableVariable o no
            get => Value;
            private set { }
        }
        public HashSet<HashSetItemVariableType> HashSetCopy
        {
            get => Value.HashSetCopy;
            private set { }
        }
    }
}