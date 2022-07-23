using UnityEngine;

public class MapTileFactory : MonoBehaviour
{
    [SerializeField]
    private MapTile _mapTilePrefab;

    public MapTile GetTilePrefab()
    {
        return _mapTilePrefab;
    }
}
