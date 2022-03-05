using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HyperGnosys.Core
{
    [CustomPropertyDrawer(typeof(TaggedPropertyExternalReference<float>))]
    public class TaggedPropertyExternalReferenceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            Object propertyRelative = property.FindPropertyRelative("referencedProperty").objectReferenceValue;
            //TaggedProperty<float> referencedProperty = (TaggedProperty<float>)propertyRelative;
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            EditorGUI.PropertyField(position, property, GUIContent.none);
            EditorGUI.EndProperty();
        }
    }
}