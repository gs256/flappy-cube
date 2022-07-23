using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class CubeBounds : MonoBehaviour
{
    public Bounds Bounds
    {
        get
        {
            Vector3 center = transform.position;
            Vector3 size = transform.localScale;
            return new Bounds(center, size);
        }
    }
}
