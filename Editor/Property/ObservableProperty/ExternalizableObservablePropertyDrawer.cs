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
            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            if (DropDownButton(position))
            {
                CreateDropDownMenu();
            }
            SerializedProperty selectedProperty;
            if (!useExternalProperty)
            {
                selectedProperty = property.FindPropertyRelative("localProperty");
                GUIContent localPropertyLabel = new GUIContent("Local Property");
                EditorGUI.PropertyField(position, selectedProperty, localPropertyLabel, true);
            }
            else
            {
                //EditorGUI.ObjectField(position, property.FindPropertyRelative("externalProperty"), GUIContent.none);
                selectedProperty = property.FindPropertyRelative("externalProperty");
                GUIContent externalPropertyLabel = new GUIContent("External Property");
                EditorGUI.PropertyField(position, selectedProperty, externalPropertyLabel, true);
            }
            EditorGUI.EndProperty();
        }
        private bool DropDownButton(Rect position)
        {
            Rect rect = new Rect(position.position, Vector2.one * 20);
            GUIContent guiContent = new GUIContent();
            GUIStyle guiStyle = new GUIStyle()
            {
                fixedWidth = 50f,
                border = new RectOffset(1, 1, 1, 1)
            };
            return EditorGUI.DropdownButton(rect, GUIContent.none, FocusType.Keyboard, guiStyle);
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