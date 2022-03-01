namespace HyperGnosys.Core
{
    public abstract class AScriptableListWrapper <ListItemType> :AScriptableProperty<ListWrapper<ListItemType>>
    {
        public ListWrapper<ListItemType> ListWrapper
        {
            get => Value;
        }
    }
}