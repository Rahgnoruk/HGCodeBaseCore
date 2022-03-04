namespace HyperGnosys.Core
{
    public class AttributesComponent : AObservablePropertyComponent<Attributes>
    {
        public TaggedProperty<AttributeType> GetAttribute<AttributeType>(PropertyTag attributeTag)
        {
            return Value.GetAttribute<AttributeType>(attributeTag);
        }
        public bool SetAttribute<AttributeType>(PropertyTag attributeTag, AttributeType newValue)
        {
            return Value.SetAttributeValue<AttributeType>(attributeTag, newValue);
        }
    }
}