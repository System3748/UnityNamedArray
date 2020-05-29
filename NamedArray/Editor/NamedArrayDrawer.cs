using System;
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(NamedArrayAttribute))]
public class NamedArrayDrawer : PropertyDrawer
{
	public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
	{
		var height = EditorGUI.GetPropertyHeight(property, label, true);
		if (property.propertyType == SerializedPropertyType.Enum)
			height *= 2;
		return height;
	}

	public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
	{
		NamedArrayAttribute namedInfo = attribute as NamedArrayAttribute;

		int index = Convert.ToInt32(property.propertyPath.Substring(property.propertyPath.IndexOf("[")).Replace("[", "").Replace("]", ""));
		//change the label

		if (namedInfo.customName != null)
		{
			label.text = namedInfo.customName + "-" + index;
		}
		else if (index + namedInfo.enumOffest >= namedInfo.enumNames.Length)
		{
			label.text = "No EnumIndex:" + index;
		}
		else
		{
			if (namedInfo.prefix != null)
			{
				label.text = namedInfo.prefix + "::" + namedInfo.enumNames[index + namedInfo.enumOffest];
			}
			else
			{
				label.text = namedInfo.enumNames[index + namedInfo.enumOffest];
			}
		}

		//draw field
		EditorGUI.PropertyField(position, property, label, true);
	}
}
