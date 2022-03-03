namespace HyperGnosys.Core
{
    public interface IAttributes
    {
        public Attribute<AttributeType> GetAttribute<AttributeType>(AttributeTag attributeTag);
        public bool SetAttributeValue<AttributeType>(AttributeTag attributeTag, AttributeType newValue);
    }
}