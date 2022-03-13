namespace HyperGnosys.Core
{
    public interface IAttributes
    {
        public TaggedProperty<AttributeType> GetAttribute<AttributeType>(PropertyTag attributeTag);
        public bool SetAttributeValue<AttributeType>(PropertyTag attributeTag, AttributeType newValue);
    }
}