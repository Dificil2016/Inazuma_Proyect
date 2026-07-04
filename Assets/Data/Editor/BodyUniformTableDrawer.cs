using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(BodyUniformTable))]
public class BodyUniformTableDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        SerializedProperty array = property.FindPropertyRelative("values");

        float height = EditorGUIUtility.singleLineHeight;

        for (int i = 0; i < array.arraySize; i++)
        {
            height += EditorGUI.GetPropertyHeight(array.GetArrayElementAtIndex(i), true) + 4;
        }

        return height;
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        SerializedProperty array = property.FindPropertyRelative("values");

        position.height = EditorGUIUtility.singleLineHeight;

        EditorGUI.LabelField(position, label);

        position.y += EditorGUIUtility.singleLineHeight + 2;

        for (int i = 0; i < array.arraySize; i++)
        {
            SerializedProperty element = array.GetArrayElementAtIndex(i);

            float h = EditorGUI.GetPropertyHeight(element, true);

            Rect rect = new Rect(position.x, position.y, position.width, h);

            string enumName = ((BodyType)i).ToString();

            EditorGUI.PropertyField(rect, element, new GUIContent(enumName), true);

            position.y += h + 4;
        }

        EditorGUI.EndProperty();
    }
}