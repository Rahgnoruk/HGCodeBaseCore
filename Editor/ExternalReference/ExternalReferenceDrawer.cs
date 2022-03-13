using UnityEditor;
using UnityEngine;

namespace HyperGnosys.Core
{
    [CustomPropertyDrawer(typeof(ExternalReference<>))]
    public class ExternalReferenceDrawer : PropertyDrawer
    {
        const float lineHeight = 16;
        const float margin = 20;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            RectCalculator rectCalculator = new RectCalculator(lineHeight, margin);

            label = new GUIContent(label.text, label.text);
            (Rect, Rect) labelAndControlRects = rectCalculator.Get1to3Rects(position);
            Rect labelRect = labelAndControlRects.Item1;
            EditorGUI.HandlePrefixLabel(position, labelRect, label, GUIUtility.GetControlID(FocusType.Passive));

            Rect controlRect = labelAndControlRects.Item2;
            SerializedProperty referencedObjectPoperty = property.FindPropertyRelative("referenceObject");
            referencedObjectPoperty.objectReferenceValue = 
                EditorGUI.ObjectField(controlRect, referencedObjectPoperty.objectReferenceValue, typeof(Object), true);

            EditorGUI.EndProperty();
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty drawnProperty = property.FindPropertyRelative("referenceObject");
            return EditorGUI.GetPropertyHeight(drawnProperty, true);
        }
    }
}