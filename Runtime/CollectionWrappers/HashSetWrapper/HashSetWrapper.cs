using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HyperGnosys.Core
{
    public class HashSetWrapper<VariableType>
    {
        [SerializeField] private HashSet<VariableType> hashSet = new HashSet<VariableType>();
        [SerializeField] private GameEvent<VariableType> onItemAdded = new GameEvent<VariableType>();
        [SerializeField] private GameEvent<VariableType> onItemRemoved = new GameEvent<VariableType>();
        [SerializeField] private GameEvent<HashSetWrapper<VariableType>> onHashSetCleared 
            = new GameEvent<HashSetWrapper<VariableType>>();
        /// <summary>
        /// Si quieres un campo expuesto de RegistryChanged, agregalo en la clase que 
        /// contenga el Registry y haz que el evento del contenedor se suscriba a
        /// OnRegistryChanged. Asi recibira eventos cuando se llame Clear().
        /// </summary>

        private VariableType lastAdded;
        private VariableType lastRemoved;

        public VariableType[] GetItemsArray()
        {
            return HashSet.ToArray();
        }
        public HashSet<VariableType> HashSetCopy
        {
            get
            {
                HashSet<VariableType> hashSetCopy = new HashSet<VariableType>();
                foreach (VariableType item in hashSet)
                {
                    hashSetCopy.Add(item);
                }
                return hashSetCopy;
            }
        }
        public void Add(VariableType item)
        {
            if (!hashSet.Contains(item))
            {
                HashSet.Add(item);
                lastAdded = item;
                RaiseItemAddedEvent(item);
            }
        }

        public bool Remove(VariableType item)
        {
            lastRemoved = item;
            RaiseItemRemovedEvent(item);
            return HashSet.Remove(item);
        }

        public int Count()
        {
            return HashSet.Count;
        }
        public void Clear()
        {
            HashSet.Clear();
            RaiseHashSetClearedEvent();
        }

        private void RaiseItemAddedEvent(VariableType item)
        {
            OnItemAdded.Raise(item);
        }
        private void RaiseItemRemovedEvent(VariableType item)
        {
            OnItemRemoved.Raise(item);
        }
        private void RaiseHashSetClearedEvent()
        {
            onHashSetCleared.Raise(this);
        }
        public bool Contains(VariableType item)
        {
            return hashSet.Contains(item);
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
            foreach (IListItem item in HashSet)
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
        public HashSet<VariableType> HashSet { get => hashSet; set => hashSet = value; }
        public GameEvent<VariableType> OnItemAdded { get => onItemAdded; set => onItemAdded = value; }
        public GameEvent<VariableType> OnItemRemoved { get => onItemRemoved; set => onItemRemoved = value; }
    }
}