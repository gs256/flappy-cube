using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TubeSpawner))]
public class TubeSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.DrawDefaultInspector();
        var mapTileSpawner = target as TubeSpawner;

        if (GUILayout.Button("Spawn"))
        {
            mapTileSpawner.SpawnTube();
            Debug.Log("Spawning");
        }
    }
}
