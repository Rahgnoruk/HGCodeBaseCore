using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class ObservableList<ContainedType> : IObservableList<ContainedType>
    {
        [SerializeField] private List<ContainedType> list = new List<ContainedType>();
        [SerializeField] private UnityEvent<ContainedType> onItemAdded = new UnityEvent<ContainedType>();
        [SerializeField] private UnityEvent<ContainedType, int> onItemReassigned = new UnityEvent<ContainedType, int>();
        [SerializeField] private UnityEvent<ContainedType> onItemRemoved = new UnityEvent<ContainedType>();
        [SerializeField] private UnityEvent onListCleared = new UnityEvent();
        [SerializeField] private UnityEvent onListReassigned = new UnityEvent();
        public void Add(ContainedType item)
        {
            list.Add(item);
            onItemAdded.Invoke(item);
        }
        public void Remove(ContainedType item)
        {
            list.Remove(item);
            onItemRemoved.Invoke(item);
        }
        public void RemoveAt(int index)
        {
            ContainedType removedValue = list[index];
            list.RemoveAt(index);
            onItemRemoved.Invoke(removedValue);
        }
        public void Clear()
        {
            list.Clear();
            onListCleared.Invoke();
        }

        public List<ContainedType> List
        {
            get => new List<ContainedType>(list);
            set
            {
                list = value;
                onListReassigned.Invoke();
            }
        }
        public ContainedType this[int index]
        {
            get => list[index];
            set
            {
                ContainedType previousValue = list[index];
                list[index] = value;
                onItemReassigned.Invoke(previousValue, index);
            }
        }


        public void AddOnItemAddedListener(UnityAction<ContainedType> listener)
        {
            onItemAdded.AddListener(listener);
        }

        public void AddOnItemReassignedListener(UnityAction<ContainedType, int> listener)
        {
            onItemReassigned.AddListener(listener);
        }

        public void AddOnItemRemovedListener(UnityAction<ContainedType> listener)
        {
            onItemRemoved.AddListener(listener);
        }

        public void AddOnListClearedListener(UnityAction listener)
        {
            onListCleared.AddListener(listener);
        }

        public void AddOnListReassignedListener(UnityAction listener)
        {
            onListReassigned.AddListener(listener);
        }

        public void RemoveOnItemAddedListener(UnityAction<ContainedType> listener)
        {
            onItemAdded.RemoveListener(listener);
        }

        public void RemoveOnItemReassignedListener(UnityAction<ContainedType, int> listener)
        {
            onItemReassigned.RemoveListener(listener);
        }

        public void RemoveOnItemRemovedListener(UnityAction<ContainedType> listener)
        {
            onItemRemoved.RemoveListener(listener);
        }

        public void RemoveOnListClearedListener(UnityAction listener)
        {
            onListCleared.RemoveListener(listener);
        }

        public void RemoveOnListReassignedListener(UnityAction listener)
        {
            onListReassigned.RemoveListener(listener);
        }
    }
}