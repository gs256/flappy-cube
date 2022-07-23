using UnityEngine;

public class MapTileRemover : MonoBehaviour
{
    [SerializeField]
    private MapTilePool _mapTilePool;

    [SerializeField]
    private CubeBounds _visibleArea;

    private void Update()
    {
        if (_mapTilePool.Objects[0].Bounds.max.x < _visibleArea.Bounds.min.x)
        {
            MapTile first = _mapTilePool.PopFirst();
            Destroy(first.gameObject);
        }
    }
}
