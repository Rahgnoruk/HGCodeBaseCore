using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public class AScriptableObservableList<ContainedType> : ScriptableObject, IObservableList<ContainedType>
    {
        [SerializeField] private ObservableList<ContainedType> observableList = new ObservableList<ContainedType>();
        public int Count { get => observableList.Count; }
        public void Add(ContainedType item)
        {
            observableList.List.Add(item);
        }
        public bool Contains(ContainedType item)
        {
            return observableList.Contains(item);
        }
        public void Remove(ContainedType item)
        {
            observableList.Remove(item);
        }
        public void RemoveAt(int index)
        {
            observableList.RemoveAt(index);
        }
        public void Clear()
        {
            observableList.Clear();
        }

        public List<ContainedType> List
        {
            get => observableList.List;
            set => observableList.List = value;
        }
        public ContainedType this[int index]
        {
            get => observableList[index];
            set => observableList[index] = value;
        }

        public void AddOnItemAddedListener(UnityAction<ContainedType> listener)
        {
            observableList.AddOnItemAddedListener(listener);
        }

        public void AddOnItemReassignedListener(UnityAction<ContainedType, int> listener)
        {
            observableList.AddOnItemReassignedListener(listener);
        }

        public void AddOnItemRemovedListener(UnityAction<ContainedType> listener)
        {
            observableList.AddOnItemRemovedListener(listener);
        }

        public void AddOnListClearedListener(UnityAction listener)
        {
            observableList.AddOnListClearedListener(listener);
        }

        public void AddOnListReassignedListener(UnityAction listener)
        {
            observableList.AddOnListReassignedListener(listener);
        }

        public void RemoveOnItemAddedListener(UnityAction<ContainedType> listener)
        {
            observableList.RemoveOnItemAddedListener(listener);
        }

        public void RemoveOnItemReassignedListener(UnityAction<ContainedType, int> listener)
        {
            observableList.RemoveOnItemReassignedListener(listener);
        }

        public void RemoveOnItemRemovedListener(UnityAction<ContainedType> listener)
        {
            observableList.RemoveOnItemRemovedListener(listener);
        }

        public void RemoveOnListClearedListener(UnityAction listener)
        {
            observableList.RemoveOnListClearedListener(listener);
        }

        public void RemoveOnListReassignedListener(UnityAction listener)
        {
            observableList.RemoveOnListReassignedListener(listener);
        }
    }
}