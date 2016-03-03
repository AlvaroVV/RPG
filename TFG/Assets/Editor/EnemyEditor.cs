using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(EnemyData))]
[CanEditMultipleObjects]
public class EnemyEditor : Editor
{

    SerializedProperty hp;
    SerializedProperty hitCount;
    SerializedProperty damage;
    SerializedProperty defense;
    SerializedProperty agility;
    SerializedProperty xp;
    SerializedProperty gold;
    SerializedProperty animController;
    SerializedProperty attacks;


    void OnEnable()
    {
        // Setup the SerializedProperties
        hp = serializedObject.FindProperty("hp");
        hitCount = serializedObject.FindProperty("hitCount");
        damage = serializedObject.FindProperty("damage");
        agility = serializedObject.FindProperty("agility");
        defense = serializedObject.FindProperty("defense");
        xp = serializedObject.FindProperty("xp");
        gold = serializedObject.FindProperty("gold");
        animController = serializedObject.FindProperty("AnimatorController");
        attacks = serializedObject.FindProperty("attacks");
    }

    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();
        // Show the custom GUI controls
      
        EditorGUILayout.IntSlider(hp, 0, 1000, new GUIContent("HP"));
        // Only show the damage progress bar if all the objects have the same damage value:
        if (!hp.hasMultipleDifferentValues)
            ProgressBar(hp.intValue / 1000.0f, "HP");

        EditorGUILayout.IntSlider(hitCount, 0, 10, new GUIContent("Hit Count"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!hitCount.hasMultipleDifferentValues)
            ProgressBar(hitCount.intValue / 10.0f, "Hit Count");

        EditorGUILayout.IntSlider(damage, 0, 100, new GUIContent("Damage"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!hitCount.hasMultipleDifferentValues)
            ProgressBar(damage.intValue / 100.0f, "Damage");

        EditorGUILayout.IntSlider(defense, 0, 100, new GUIContent("Defense"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!hitCount.hasMultipleDifferentValues)
            ProgressBar(defense.intValue / 100.0f, "Defense");

        EditorGUILayout.IntSlider(agility, 0, 100, new GUIContent("Agility"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!hitCount.hasMultipleDifferentValues)
            ProgressBar(agility.intValue / 100.0f, "Agility");

        EditorGUILayout.PropertyField(animController, new GUIContent("AnimController"));
        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.

        EditorGUILayout.PropertyField(attacks, true);


        serializedObject.ApplyModifiedProperties();

        
    }

    void CustomList()
    {

    }

    // Custom GUILayout progress bar.
    void ProgressBar(float value, string label)
    {
        // Get a rect for the progress bar using the same margins as a textfield:
        Rect rect = GUILayoutUtility.GetRect(18, 18, "TextField");
        EditorGUI.ProgressBar(rect, value, label);
        EditorGUILayout.Space();
    }
}