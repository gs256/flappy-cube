using UnityEngine;

public class MapTile : MonoBehaviour
{
    [SerializeField]
    private CubeBounds _bounds;

    [SerializeField]
    private Tube[] _tubes;

    public Bounds Bounds => _bounds.Bounds;
    public Tube[] Tubes => _tubes;
}
