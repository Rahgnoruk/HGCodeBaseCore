namespace HyperGnosys.Core
{
    public class AttributesComponent : AObservablePropertyComponent<Attributes>
    {
        public Attribute<AttributeType> GetAttribute<AttributeType>(AttributeTag attributeTag)
        {
            return Value.GetAttribute<AttributeType>(attributeTag);
        }
        public bool SetAttribute<AttributeType>(AttributeTag attributeTag, AttributeType newValue)
        {
            return Value.SetAttributeValue<AttributeType>(attributeTag, newValue);
        }
    }
}