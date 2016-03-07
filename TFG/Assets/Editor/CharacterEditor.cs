﻿using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(BaseStatCharacter))]
[CanEditMultipleObjects]
public class CharacterEditor : Editor {

    SerializedProperty name;
    SerializedProperty description;
    SerializedProperty healthPoints;
    SerializedProperty magicPoints;
    SerializedProperty characterType;
    SerializedProperty experience;
    SerializedProperty abilityPoints;
    SerializedProperty attackPower;
    SerializedProperty defensePower;
    SerializedProperty magicPower;
    SerializedProperty magicDefense;
    SerializedProperty speed;
    SerializedProperty evasion;
    SerializedProperty animController;
    SerializedProperty attacks;


    void OnEnable()
    {
        // Setup the SerializedProperties
        name = serializedObject.FindProperty("name");
        description = serializedObject.FindProperty("description");
        healthPoints = serializedObject.FindProperty("healthPoints");
        magicPoints = serializedObject.FindProperty("magicPoints");
        characterType = serializedObject.FindProperty("type");
        experience = serializedObject.FindProperty("experience");
        abilityPoints = serializedObject.FindProperty("abilityPoints");
        attackPower = serializedObject.FindProperty("attackPower");
        defensePower = serializedObject.FindProperty("defensePower");
        magicPower = serializedObject.FindProperty("magicPower");
        magicDefense = serializedObject.FindProperty("magicDefense");
        speed = serializedObject.FindProperty("speed");
        evasion = serializedObject.FindProperty("evasion");
        animController = serializedObject.FindProperty("animatorController");
        attacks = serializedObject.FindProperty("Attacks");
    }

    public override void OnInspectorGUI()
    {
        // Update the serializedProperty - always do this in the beginning of OnInspectorGUI.
        serializedObject.Update();
        // Show the custom GUI controls

        EditorGUILayout.PropertyField(name, new GUIContent("Name"));
        EditorGUILayout.PropertyField(description, new GUIContent("Description"));
        EditorGUILayout.PropertyField(characterType, new GUIContent("Type"), true);

        EditorGUILayout.IntSlider(healthPoints, 0, 1000, new GUIContent("healthPoints"));
        // Only show the damage progress bar if all the objects have the same damage value:
        if (!healthPoints.hasMultipleDifferentValues)
            ProgressBar(healthPoints.intValue / 1000.0f, "healthPoints");

        EditorGUILayout.IntSlider(magicPoints, 0, 1000, new GUIContent("magicPoints"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!magicPoints.hasMultipleDifferentValues)
            ProgressBar(magicPoints.intValue / 1000f, "magicPoints");

        EditorGUILayout.IntSlider(experience, 0, 100, new GUIContent("experience"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!experience.hasMultipleDifferentValues)
            ProgressBar(experience.intValue / 100.0f, "experience");

        EditorGUILayout.IntSlider(abilityPoints, 0, 100, new GUIContent("abilityPoints"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!abilityPoints.hasMultipleDifferentValues)
            ProgressBar(abilityPoints.intValue / 100.0f, "abilityPoints");

        EditorGUILayout.IntSlider(attackPower, 0, 100, new GUIContent("attackPower"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!attackPower.hasMultipleDifferentValues)
            ProgressBar(attackPower.intValue / 100.0f, "attackPower");

        EditorGUILayout.IntSlider(defensePower, 0, 100, new GUIContent("defensePower"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!defensePower.hasMultipleDifferentValues)
            ProgressBar(defensePower.intValue / 100.0f, "defensePower");

        EditorGUILayout.IntSlider(magicPower, 0, 100, new GUIContent("magicPower"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!magicPower.hasMultipleDifferentValues)
            ProgressBar(magicPower.intValue / 100.0f, "magicPower");

        EditorGUILayout.IntSlider(magicDefense, 0, 100, new GUIContent("magicDefense"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!magicDefense.hasMultipleDifferentValues)
            ProgressBar(magicDefense.intValue / 100.0f, "magicDefense");

        EditorGUILayout.IntSlider(speed, 0, 100, new GUIContent("speed"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!speed.hasMultipleDifferentValues)
            ProgressBar(speed.intValue / 100.0f, "speed");

        EditorGUILayout.IntSlider(speed, 0, 100, new GUIContent("evasion"));
        // Only show the armor progress bar if all the objects have the same armor value:
        if (!evasion.hasMultipleDifferentValues)
            ProgressBar(evasion.intValue / 100.0f, "evasion");

        EditorGUILayout.PropertyField(animController, new GUIContent("AnimController"));
        // Apply changes to the serializedProperty - always do this in the end of OnInspectorGUI.

        EditorGUILayout.PropertyField(attacks, new GUIContent("Attacks"), true);

        serializedObject.ApplyModifiedProperties();

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