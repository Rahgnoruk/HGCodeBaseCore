namespace HyperGnosys.Core
{
    public abstract class AScriptableListWrapper <ListItemType> :AScriptableObservableProperty<ListWrapper<ListItemType>>
    {
        public ListWrapper<ListItemType> ListWrapper
        {
            get => Value;
        }
    }
}