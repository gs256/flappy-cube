using UnityEngine;

public class MapTile : MonoBehaviour
{
    [SerializeField]
    private CubeBounds _bounds;

    public Bounds Bounds => _bounds.Bounds;
}
