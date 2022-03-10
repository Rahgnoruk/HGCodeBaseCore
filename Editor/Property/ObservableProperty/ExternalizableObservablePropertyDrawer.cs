using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace HyperGnosys.Core
{
    [CustomPropertyDrawer(typeof(ExternalizableObservableProperty<>))]
    public class ExternalizableObservablePropertyDrawer : PropertyDrawer
    {
        private SerializedProperty serializedProperty;
        private bool useExternalProperty = false;
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            serializedProperty = property;
            useExternalProperty = property.FindPropertyRelative("useExternalProperty").boolValue;

            label = new GUIContent(label.text, label.text);
            Rect labelRect = CalculateLabelRect(position);
            EditorGUI.HandlePrefixLabel(position, labelRect, label, GUIUtility.GetControlID(FocusType.Passive));

            Rect selectorRect = CalculateSelectorRect(labelRect);
            Rect controlRect = CalculateControlRect(position, selectorRect);
            

            if (DropDownButton(selectorRect))
            {
                CreateDropDownMenu();
            }
            SerializedProperty selectedProperty;
            if (!useExternalProperty)
            {
                selectedProperty = property.FindPropertyRelative("localProperty");
                GUIContent localPropertyLabel = new GUIContent("Local Property");
                EditorGUI.PropertyField(controlRect, selectedProperty, localPropertyLabel, true);
            }
            else
            {
                //EditorGUI.ObjectField(position, property.FindPropertyRelative("externalProperty"), GUIContent.none);
                selectedProperty = property.FindPropertyRelative("externalProperty");
                GUIContent externalPropertyLabel = new GUIContent("External Property");
                EditorGUI.PropertyField(controlRect, selectedProperty, externalPropertyLabel, true);
            }
            EditorGUI.EndProperty();
        }
        private Rect CalculateLabelRect(Rect position)
        {
            float labelWidth = position.width / 4;
            return new Rect(position.x, position.y, labelWidth, 16);
        }
        private Rect CalculateSelectorRect(Rect labelRect)
        {
            float xPosition = labelRect.x + labelRect.width + 10;
            return new Rect(xPosition, labelRect.y, 10, 16);
        }
        private Rect CalculateControlRect(Rect position, Rect selectorRect)
        {
            float controlXPosition = selectorRect.x + selectorRect.width + 20;
            float controlWidth = (position.width/4) * 2.5f;
            return new Rect(controlXPosition, position.y, controlWidth, position.height);
        }
        private bool DropDownButton(Rect rect)
        {
            GUIContent guiContent = new GUIContent("S");
            GUIStyle guiStyle = new GUIStyle()
            {
                fixedWidth = 50f,
                border = new RectOffset(1, 1, 1, 1)
            };
            return EditorGUI.DropdownButton(rect, guiContent, FocusType.Keyboard, guiStyle);
        }
        private void CreateDropDownMenu()
        {
            GenericMenu menu = new GenericMenu();
            menu.AddItem(new GUIContent("Local"),
                !useExternalProperty,
                () => SetProperty(false));
            menu.AddItem(new GUIContent("External"),
                useExternalProperty,
                () => SetProperty(true));
            menu.ShowAsContext();
        }
        private void SetProperty(bool value)
        {
            SerializedProperty propertyRelative = serializedProperty.FindPropertyRelative("useExternalProperty");
            propertyRelative.boolValue = value;
            serializedProperty.serializedObject.ApplyModifiedProperties();
        }
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty drawnProperty;
            if (!useExternalProperty)
            {
                drawnProperty = property.FindPropertyRelative("localProperty");
            }
            else
            {
                drawnProperty = property.FindPropertyRelative("externalProperty");
            }
            return EditorGUI.GetPropertyHeight(drawnProperty, true);
        }
    }
}