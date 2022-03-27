using System.Collections.Generic;
using UnityEngine.Events;

namespace HyperGnosys.Core
{
    public interface IObservableList<ContainedType>
    {
        int Count { get; }
        void Add(ContainedType item);
        void Remove(ContainedType item);
        void RemoveAt(int index);
        void Clear();
        List<ContainedType> List { get; set; }
        ContainedType this[int index] { get;set; }
        void AddOnItemAddedListener(UnityAction<ContainedType> listener);
        void AddOnItemReassignedListener(UnityAction<ContainedType, int> listener);
        void AddOnItemRemovedListener(UnityAction<ContainedType> listener);
        void AddOnListClearedListener(UnityAction listener);
        void AddOnListReassignedListener(UnityAction listener);
        void RemoveOnItemAddedListener(UnityAction<ContainedType> listener);
        void RemoveOnItemReassignedListener(UnityAction<ContainedType, int> listener);
        void RemoveOnItemRemovedListener(UnityAction<ContainedType> listener);
        void RemoveOnListClearedListener(UnityAction listener);
        void RemoveOnListReassignedListener(UnityAction listener);
    }
}