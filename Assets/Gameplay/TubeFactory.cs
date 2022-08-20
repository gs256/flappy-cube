using UnityEngine;

public class TubeFactory : MonoBehaviour
{
    [SerializeField]
    private Tube _tubePrefab;

    internal Tube GetTubePrefab()
    {
        return _tubePrefab;
    }
}
