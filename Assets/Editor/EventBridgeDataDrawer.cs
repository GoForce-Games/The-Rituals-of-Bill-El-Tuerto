using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomPropertyDrawer(typeof(EventBridgeData))]
public class EventBridgeBindDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Start property drawing
        EditorGUI.BeginProperty(position, label, property);

        // Calculate rects
        float lineHeight = EditorGUIUtility.singleLineHeight;
        Rect bridgeRect = new Rect(position.x, position.y, position.width, lineHeight);
        Rect dropDownRect = new Rect(position.x, position.y + lineHeight + 2, position.width, lineHeight);

        // Get the properties
        SerializedProperty eventBridgeProp = property.FindPropertyRelative("eventBridge");
        SerializedProperty eventNameProp = property.FindPropertyRelative("eventName");

        // Draw the EventBridge field
        EditorGUI.PropertyField(bridgeRect, eventBridgeProp);

        EventBridge eventBridge = eventBridgeProp.objectReferenceValue as EventBridge;

        if (eventBridge)
        {
            List<string> eventNames = eventBridge.events.ConvertAll(e => e.eventName);
            int selectedIndex = Mathf.Max(0, eventNames.IndexOf(eventNameProp.stringValue));
            selectedIndex = EditorGUI.Popup(dropDownRect, "Event Name", selectedIndex, eventNames.ToArray());

            eventNameProp.stringValue = eventNames[selectedIndex];
        }
        else
        {
            EditorGUI.HelpBox(dropDownRect, "Assign an EventBridge to choose an event", MessageType.Info);
        }

        EditorGUI.EndProperty();
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUIUtility.singleLineHeight * 2 + 4;
    }
}