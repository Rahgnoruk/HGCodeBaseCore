using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace HyperGnosys.Core
{
    [CustomPropertyDrawer(typeof(TaggedPropertyReferenceFromGroup<>))]
    public class TaggedPropertyReferenceFromGroupDrawer : PropertyDrawer
    {
        const float lineHeight = 16;
        const float margin = 20;
        RectCalculator rectCalculator;
        List<Rect> lines;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            
            lines = new List<Rect>();
            rectCalculator = new RectCalculator(lineHeight, margin);

            label = new GUIContent(label.text, label.text);
            Rect labelRect = rectCalculator.GetFullWidthRect(position);
            EditorGUI.HandlePrefixLabel(position, labelRect, label, GUIUtility.GetControlID(FocusType.Passive));

            Rect propertyGroupLine = rectCalculator.GetNextLineContainer(position);
            SerializedProperty propertyGroup = property.FindPropertyRelative("propertyGroup");
            EditorGUI.PropertyField(propertyGroupLine, propertyGroup, true);
            lines.Add(propertyGroupLine);

            Rect tagLine = rectCalculator.GetNextLineContainer(propertyGroupLine);
            SerializedProperty tag = property.FindPropertyRelative("tag");
            GUIContent tagLabel = new GUIContent("Property Tag");
            tag.objectReferenceValue = EditorGUI.ObjectField(tagLine, tagLabel, tag.objectReferenceValue, typeof(PropertyTag), true);
            lines.Add(tagLine);

            Rect referencedPropertyRect = rectCalculator.GetNextLineContainer(tagLine);
            SerializedProperty referencedProperty = property.FindPropertyRelative("propertyPreview");
            GUI.enabled = false;
            EditorGUI.PropertyField(referencedPropertyRect, referencedProperty, true);
            GUI.enabled = true;
            lines.Add(referencedPropertyRect);

            property.serializedObject.ApplyModifiedProperties();
            EditorGUI.EndProperty();
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty drawnProperty = property.FindPropertyRelative("propertyPreview");
            return rectCalculator.CalculateTotalHeigh(drawnProperty, lines.ToArray());
        }
    }
}