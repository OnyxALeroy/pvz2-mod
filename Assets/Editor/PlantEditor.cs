using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Plant))]
public class PlantEditor : Editor
{
    void DrawCategory(string header, params string[] propertyNames)
    {
        EditorGUILayout.Space(10);
        EditorGUILayout.LabelField(header, EditorStyles.boldLabel);

        foreach (string propName in propertyNames)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty(propName));
        }

        EditorGUILayout.Space(10);
    }

    void DrawHorizontalLine(Color color, float height = 1f, float padding = 10f)
    {
        Rect rect = EditorGUILayout.GetControlRect(false, height + padding);
        rect.height = height;
        rect.y += padding / 2f;
        EditorGUI.DrawRect(rect, color);
    }

    // --------------------------------------------------------------------------------------------

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawCategory("Plant Infos", "plantName", "description", "sunCost", "seedRecharge", "maxHealth");

        var typeProp = serializedObject.FindProperty("type");
        EditorGUILayout.PropertyField(typeProp);
        EditorGUILayout.Space(10);
        DrawHorizontalLine(Color.gray);

        var plantType = (PlantType)typeProp.enumValueIndex;

        switch (plantType)
        {
            case PlantType.SunProducer:
                DrawCategory("Sun Producer-relative Infos", "productionAmount", "productionCooldown");
                DrawHorizontalLine(Color.gray); 
                break;

            case PlantType.Attacker:
                DrawCategory("Attacker-relative Infos", "attackDamage", "range", "doShoot", "fireRate", "projectileVelocity");
                DrawHorizontalLine(Color.gray); 
                break;
        }

        DrawCategory("Plant Components", "plantObject", "auxiliaryObjects");
        DrawCategory("Seed Slot Components", "slotBackground", "plantSeed");
        DrawHorizontalLine(Color.gray);

        serializedObject.ApplyModifiedProperties();
    }
}
