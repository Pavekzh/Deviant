using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Arena.GeneralShootingModule))]
public class GeneralShootingModuleEditor : Editor
{

    Arena.GeneralShootingModule script;
    private void OnEnable()
    {
        script = target as Arena.GeneralShootingModule;
    }

    public override void OnInspectorGUI()
    {
        DrawPropertiesExcluding(serializedObject,"heatLevel","reloadProgress", "shotsCount", "animateCooldown", "preciseCooldown","preciseReload", "animateReload");

        EditorGUILayout.PropertyField(serializedObject.FindProperty("animateCooldown"));
        if (!serializedObject.FindProperty("animateCooldown").boolValue)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("preciseCooldown"));
            GUILayout.EndHorizontal();
        }

        EditorGUILayout.PropertyField(serializedObject.FindProperty("animateReload"));
        if (!serializedObject.FindProperty("animateReload").boolValue)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(10);
            EditorGUILayout.PropertyField(serializedObject.FindProperty("preciseReload"));
            GUILayout.EndHorizontal();
        }

        EditorGUI.BeginDisabledGroup(true);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("heatLevel"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("reloadProgress"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("shotsCount"));
        EditorGUI.EndDisabledGroup();


        

        serializedObject.ApplyModifiedProperties();
    }
}
