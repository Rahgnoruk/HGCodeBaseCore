using UnityEditor;
using UnityEngine;

namespace HyperGnosys.Core
{
    [CustomPropertyDrawer(typeof(ExternalReference<>))]
    public class ExternalReferenceDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            label = new GUIContent(label.text, label.text);
            Rect labelRect = CalculateLabelRect(position);
            EditorGUI.HandlePrefixLabel(position, labelRect, label, GUIUtility.GetControlID(FocusType.Passive));

            Rect controlRect = CalculateControlRect(position, labelRect);
            SerializedProperty referencedObjectPoperty = property.FindPropertyRelative("referenceObject");
            EditorGUI.ObjectField(controlRect, referencedObjectPoperty.objectReferenceValue, typeof(Object), true);

            EditorGUI.EndProperty();
        }
        private Rect CalculateLabelRect(Rect position)
        {
            float labelWidth = position.width / 2.5f;
            return new Rect(position.x, position.y, labelWidth, 16);
        }
        private Rect CalculateControlRect(Rect position, Rect labelRect)
        {
            float controlXPosition = labelRect.x + labelRect.width + 20;
            float controlWidth = labelRect.width * 1.4f;
            return new Rect(controlXPosition, position.y, controlWidth, position.height);
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty drawnProperty = property.FindPropertyRelative("referenceObject");
            return EditorGUI.GetPropertyHeight(drawnProperty, true);
        }
    }
}