using System;
using System.Collections.Generic;
using UnityEngine;

namespace HyperGnosys.Core
{
    [Serializable]
    public class ListWrapper<VariableType>
    {
        [SerializeField] private List<VariableType> list = new List<VariableType>();
        [SerializeField] private GameEvent<VariableType> onItemAdded = new GameEvent<VariableType>();
        [SerializeField] private GameEvent<VariableType> onItemRemoved = new GameEvent<VariableType>();
        [SerializeField] private GameEvent<ListWrapper<VariableType>> onListCleared 
            = new GameEvent<ListWrapper<VariableType>>();
        /// <summary>
        /// Si quieres un campo expuesto de RegistryChanged, agregalo en la clase que 
        /// contenga el Registry y haz que el evento del contenedor se suscriba a
        /// OnRegistryChanged. Asi recibira eventos cuando se llame Clear().
        /// </summary>

        private VariableType lastAdded;
        private VariableType lastRemoved;

        public VariableType[] ToArray()
        {
            return list.ToArray();
        }
        public List<VariableType> List
        {
            get => new List<VariableType>(list);
        }
        public void Add(VariableType item)
        {
            if (!list.Contains(item))
            {
                list.Add(item);
                lastAdded = item;
                RaiseItemAddedEvent(item);
            }
        }
        public bool Contains(VariableType item)
        {
            return list.Contains(item);
        }
        public bool Remove(VariableType item)
        {
            lastRemoved = item;
            bool wasRemoved = list.Remove(item);
            if(wasRemoved) RaiseItemRemovedEvent(item);
            return wasRemoved;
        }
        public void RemoveAt(int index)
        {
            RaiseItemRemovedEvent(list[index]);
            list.RemoveAt(index);
        }
        public int Count { get => list.Count; }
        public void Clear()
        {
            RaiseListClearedEvent();
            list.Clear();
        }

        private void RaiseItemAddedEvent(VariableType item)
        {
            onItemAdded.Raise(item);
        }
        private void RaiseItemRemovedEvent(VariableType item)
        {
            onItemRemoved.Raise(item);
        }
        private void RaiseListClearedEvent()
        {
            onListCleared.Raise(this);
        }

        /// <summary>
        /// Este metodo sirve si los elementos del registro implementan 
        /// la interfaz de IRegistryItem, pero no es obligatorio que lo
        /// implementen para que el registro funcione.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual IListItem GetItemByID(int id)
        {
            foreach (IListItem item in list)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return default;
        }
        public VariableType LastAdded { get => lastAdded; }
        public VariableType LastRemoved { get => lastRemoved; }
        public GameEvent<VariableType> OnItemAdded { get => onItemAdded; set => onItemAdded = value; }
        public GameEvent<VariableType> OnItemRemoved { get => onItemRemoved; set => onItemRemoved = value; }
        public GameEvent<ListWrapper<VariableType>> OnListCleared { get => onListCleared; set => onListCleared = value; }
    }
}