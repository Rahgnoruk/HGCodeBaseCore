using System.Collections.Generic;
using UnityEngine;

namespace HyperGnosys.Core
{
    [System.Serializable]
    public class TaggedPropertyGroup<PropertyType> 
        : Dictionary<PropertyTag, TaggedProperty<PropertyType>>, 
        ISerializationCallbackReceiver, 
        ITaggedPropertyGroup<PropertyType>
    {
        [SerializeField] private TaggedProperty<PropertyType>[] properties;

        //After serialization is done, load the array that survived serialization
        //into the dictionary so it can be used.
        public void OnAfterDeserialize()
        {
            if (properties == null) return;
            this.Clear();
            for (int i = 0; i < properties.Length; i++)
            {
                if (properties[i] == null || properties[i].Tag == null)
                    continue;
                if (this.ContainsKey(properties[i].Tag))
                {
                    Debug.LogWarning($"Property number {i+1} has a tag that already exists " +
                        $"in the TaggedPropertyGroup. Skipping");
                    //this[properties[i].Tag].Value = properties[i].Value;
                    continue;
                }
                this.Add(properties[i].Tag, properties[i]);
            }
        }
        //Before serialization starts, save changes in the non serializable dictionary into 
        // the serializable array
        public void OnBeforeSerialize()
        {
            if(this.Keys.Count > properties.Length)
            {
                TaggedProperty<PropertyType>[] newArray = new TaggedProperty<PropertyType>[Keys.Count];
                LoadIntoArray(newArray);
                return;
            }
            LoadIntoArray(properties);
        }
        private void LoadIntoArray(TaggedProperty<PropertyType>[] array)
        {
            int i = 0;
            foreach (KeyValuePair<PropertyTag, TaggedProperty<PropertyType>> pair in this)
            {
                array[i] = pair.Value;
                i++;
            }
            properties = array;
        }
    }
}