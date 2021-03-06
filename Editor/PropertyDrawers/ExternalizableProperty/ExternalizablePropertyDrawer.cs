using UnityEditor;
using UnityEngine;
namespace HyperGnosys.Core
{
    public class ExternalizablePropertyDrawer : PropertyDrawer
    {
        const float lineHeight = 16;
        const float margin = 20;
        private SerializedProperty serializedProperty;
        protected bool useExternalProperty = false;
        protected string externalReferenceName = "externalProperty";
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            RectCalculator rectCalculator = new RectCalculator(lineHeight, margin);

            serializedProperty = property;
            useExternalProperty = property.FindPropertyRelative("useExternalProperty").boolValue;

            label = new GUIContent(label.text, label.text);
            (Rect, Rect) labelAndControlRects = rectCalculator.Get1to4Rects(position);
            Rect labelRect = labelAndControlRects.Item1;
            EditorGUI.HandlePrefixLabel(position, labelRect, label, GUIUtility.GetControlID(FocusType.Passive));

            (Rect, Rect) selectorAndPropertyRects = rectCalculator.GetRectsFromFirstRectWidth(labelAndControlRects.Item2, 10);
            Rect selectorRect = selectorAndPropertyRects.Item1;
            Rect propertyRect = selectorAndPropertyRects.Item2;


            if (DropDownButton(selectorRect))
            {
                CreateDropDownMenu();
            }
            SerializedProperty selectedProperty;
            if (!useExternalProperty)
            {
                selectedProperty = property.FindPropertyRelative("localProperty");
                GUIContent localPropertyLabel = new GUIContent("Local Property");
                EditorGUI.PropertyField(propertyRect, selectedProperty, localPropertyLabel, true);
            }
            else
            {
                selectedProperty = property.FindPropertyRelative(externalReferenceName);
                GUIContent externalPropertyLabel = new GUIContent("External Property");
                EditorGUI.PropertyField(propertyRect, selectedProperty, externalPropertyLabel, true);
            }
            property.serializedObject.ApplyModifiedProperties();
            EditorGUI.EndProperty();
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
                drawnProperty = property.FindPropertyRelative(externalReferenceName);
            }
            return EditorGUI.GetPropertyHeight(drawnProperty, true);
        }
    }
}