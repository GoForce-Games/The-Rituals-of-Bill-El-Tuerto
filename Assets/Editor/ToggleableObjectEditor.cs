using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ToggleableObject))]
[CanEditMultipleObjects]
public class ToggleableObjectEditor : Editor
{
    SerializedProperty eventBridgeProp;
    SerializedProperty eventNameProp;

    void OnEnable()
    {
        eventBridgeProp = serializedObject.FindProperty("eventBridge");
        eventNameProp = serializedObject.FindProperty("eventName");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(eventBridgeProp);

        ToggleableObject toggleable = (ToggleableObject)target;
        EventBridge bridge = toggleable.eventBridge;

        if (bridge != null)
        {
            var eventNames = bridge.events.ConvertAll(e => e.eventName);
            int currentIndex = eventNames.IndexOf(eventNameProp.stringValue);
            if (currentIndex < 0) currentIndex = 0;

            int selectedIndex = EditorGUILayout.Popup("Event Name", currentIndex, eventNames.ToArray());

            eventNameProp.stringValue = eventNames[selectedIndex];
        }
        else
        {
            EditorGUILayout.HelpBox("Assign an EventBridge to choose an event.", MessageType.Info);
            EditorGUILayout.PropertyField(eventNameProp);
        }

        serializedObject.ApplyModifiedProperties();
    }
}