namespace HyperGnosys.Core
{
    public interface ITaggedPropertyGroup<PropertyType>
    {
        TaggedProperty<PropertyType> this[PropertyTag key] { get; set; }
    }
}