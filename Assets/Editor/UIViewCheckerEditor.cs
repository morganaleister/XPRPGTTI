using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(UIViewChecker))]
public class UIViewCheckerEditor : Editor
{
    // Override the OnInspectorGUI method to customize the inspector display
    public override void OnInspectorGUI()
    {
        // Cast the target object to UIViewChecker type
        UIViewChecker viewChecker = (UIViewChecker)target;

        // Draw the default inspector GUI
        DrawDefaultInspector();

        // Check if the debug flag is true
        if (viewChecker.debug)
        {
            // Display the read-only offset values for each side
            EditorGUILayout.LabelField("Offset Left", viewChecker.OffsetLeft.ToString());
            EditorGUILayout.LabelField("Offset Right", viewChecker.OffsetRight.ToString());
            EditorGUILayout.LabelField("Offset Top", viewChecker.OffsetTop.ToString());
            EditorGUILayout.LabelField("Offset Bottom", viewChecker.OffsetBottom.ToString());
        }
    }
}