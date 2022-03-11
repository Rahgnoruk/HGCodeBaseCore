namespace HyperGnosys.Core
{
    public interface ITaggedPropertyGroup<PropertyType>
    {
        TaggedProperty<PropertyType> GetPropertyByTag(PropertyTag tag);
    }
}