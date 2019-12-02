using UnityEditor;
using UnityEngine;
using System;
using UnityEngine.UIElements;

[CustomEditor(typeof(SpriteToWorld))]
public class STWExtender : Editor
{
    private SpriteToWorld _stw;
        //(MyWindow)EditorWindow.GetWindow(typeof(MyWindow));
    public override void OnInspectorGUI()
    {
        _stw = (SpriteToWorld)target;

        DrawDefaultInspector();
        if (GUILayout.Button("Generate World"))
        {
            _stw.SpawnWorld();
        }
        //if (GUILayout.Button("Generate Ore", GUILayout.Width(100f)))
        //{
        //    _stw.OreTheWorld();
        //}
        if (GUILayout.Button("Spawn Player"))
        {
            _stw.SpawnPlayer();
        }
        if (GUILayout.Button("Delete World"))
        {
            _stw.DeleteTheWorld();
        }
    }
}
