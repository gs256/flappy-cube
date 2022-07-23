using UnityEngine;

public class MapTileSpawner : MonoBehaviour
{
    [SerializeField]
    private MapTileFactory _mapTileFactory;

    [SerializeField]
    private MapTilePool _mapTilePool;

    [SerializeField]
    private CubeBounds _visibleArea;

    private MapTile _lastTile;

    private void Start()
    {
        Spawn();
    }

    private void Update()
    {
        if (_lastTile.Bounds.max.x < _visibleArea.Bounds.max.x)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        MapTile tilePrefab = _mapTileFactory.GetTilePrefab();
        var position = new Vector3(tilePrefab.Bounds.size.x, 0, 0);

        if (_lastTile == null)
        {
            var tile = Instantiate(tilePrefab, position, Quaternion.identity);
            _lastTile = tile;
            _mapTilePool.Add(tile);
        }
        else
        {
            var tile = Instantiate(tilePrefab, _lastTile.transform);
            tile.transform.localPosition = position;
            tile.transform.SetParent(null);
            _lastTile = tile;
            _mapTilePool.Add(tile);
        }
    }
}
