using System;
using System.Collections.Generic;

namespace HyperGnosys.Core
{
    /// <summary>
    /// El comportamiento base es el mismo que el AProperty
    /// Se agregaron Getters mas directos y legibles para obtener el ListWrapper y la lista
    /// </summary>
    /// <typeparam name="ListItemType"></typeparam>
    /// <typeparam name="ScriptableRegistryEventType"></typeparam>
    /// RECUERDA MARCAR SERIALIZABLES LAS CLASES QUE HEREDEN
    [Serializable]
    public class ListProperty<ListItemType> : Property <ListWrapper<ListItemType>>
    {
        public override ListWrapper<ListItemType> Value
        {
            get => base.Value;
        }
        public ListItemType[] GetItemsArray()
        {
            return Value.ToArray();
        }
        public void Add(ListItemType item)
        {
            Value.Add(item);
        }
        public bool Contains(ListItemType item)
        {
            return Value.Contains(item);
        }
        public bool Remove(ListItemType item)
        {
            return Value.Remove(item);
        }
        public void RemoveAt(int index)
        {
            Value.RemoveAt(index);
        }
        public int Count { get => Value.Count; }
        public void Clear()
        {
            Value.Clear();
        }
        public ListWrapper<ListItemType> ListWrapper
        {
            ///Value ya hace la evaluacion de si debe usar ScriptableVariable o no
            get => Value;
        }
        public List<ListItemType> List
        {
            get => Value.List;
        }
        public GameEvent<ListItemType> OnItemAdded { get => Value.OnItemAdded; }
        public GameEvent<ListItemType> OnItemRemoved { get => Value.OnItemRemoved; }
        public GameEvent<ListWrapper<ListItemType>> OnListCleared { get => Value.OnListCleared; }

    }
}