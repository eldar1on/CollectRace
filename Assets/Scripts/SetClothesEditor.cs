using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(SetClothes))]
public class SetClothesEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SetClothes myScript = (SetClothes)target;
        if (GUILayout.Button("Change Clothes"))
        {
            myScript.ChangeCostume();
        }
    }
}