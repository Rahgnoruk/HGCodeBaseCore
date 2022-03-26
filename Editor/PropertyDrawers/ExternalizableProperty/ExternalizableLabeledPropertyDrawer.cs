using UnityEditor;
using UnityEngine;

namespace HyperGnosys.Core
{
    [CustomPropertyDrawer(typeof(ExternalizableLabeledProperty<>))]
    public class ExternalizableLabeledPropertyDrawer : ExternalizablePropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            externalReferenceName = "propertyInGroup";
            base.OnGUI(position, property, label);
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            externalReferenceName = "propertyInGroup";
            return base.GetPropertyHeight(property, label);
        }
    }
}