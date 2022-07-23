using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MapTileSpawner))]
public class MapTileSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        var mapTileSpawner = target as MapTileSpawner;

        if (GUILayout.Button("Spawn"))
        {
            mapTileSpawner.Spawn();
            Debug.Log("Spawning");
        }
    }
}
