using UnityEngine;

public class TubeFactory : MonoBehaviour, ITubeFactory
{
    [SerializeField]
    private Tube _tubePrefab;

    public Tube GetPrefab()
    {
        return _tubePrefab;
    }
}
