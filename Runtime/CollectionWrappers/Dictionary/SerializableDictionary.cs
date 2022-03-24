using System.Collections.Generic;
using UnityEngine;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField] private List<TKey> keys = new List<TKey>();
        [SerializeField] private List<TValue> values = new List<TValue>();
        // After the lists survived serialization,
        // load the values to the dictionary
        public void OnAfterDeserialize()
        {
            this.Clear();
            CheckSynch();
            for (int i = 0; i < keys.Count; i++)
            {
                if (this.ContainsKey(keys[i]))
                {
                    Debug.LogWarning($"Key with Index {i} already exists in the dictionary. Skipping");
                    continue;
                }
                this.Add(keys[i], values[i]);
            }
        }
        // Before serialization starts, save changes to the dictionary
        // in the lists that will surive serialization
        public void OnBeforeSerialize()
        {
            int i = 0;
            CheckSynch();
            foreach (KeyValuePair<TKey, TValue> pair in this)
            {
                bool iIsBiggerThanList = i > keys.Count - 1;
                if (iIsBiggerThanList)
                {
                    keys.Add(pair.Key);
                    values.Add(pair.Value);
                }
                else
                {
                    keys[i] = pair.Key;
                    values[i] = pair.Value;
                }
                i++;
            }
        }
        private void CheckSynch()
        {
            if (keys.Count > values.Count)
            {
                for (int i = keys.Count - values.Count; i > 0; i--)
                {
                    values.Add(default(TValue));
                }
            }
            else if (keys.Count < values.Count)
            {
                int difference = values.Count - keys.Count;
                for (int i = 1; i <= difference; i++)
                {
                    values.RemoveAt(values.Count - i);
                }
            }
        }
    }
}