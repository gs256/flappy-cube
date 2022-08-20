using UnityEngine;

public class TubeSpawner : MonoBehaviour
{
    [SerializeField]
    private TubeFactory _tubeFactory;

    [SerializeField]
    private TubeHolder _tubeHolder;

    [SerializeField]
    private CubeBounds _gameArea;

    [SerializeField]
    private float _spaceBetweenTubes;

    private readonly TubeSetup _tubeSetup = new TubeSetup();
    private Tube _lastTube;

    private void Start()
    {
        // Spawn();
    }

    private void Update()
    {
        if (ShouldSpawnTube())
            SpawnTube();
    }

    public void SpawnTube()
    {
        Tube tubePrefab = _tubeFactory.GetTubePrefab();
        Bounds bounds = _gameArea.Bounds;
        var tubePosition = new Vector3(bounds.max.x, bounds.center.y, bounds.center.z);

        Tube tube = Instantiate(tubePrefab, tubePosition, Quaternion.identity);
        _tubeSetup.SetupTube(tube);
        _lastTube = tube;
        _tubeHolder.Add(tube);
    }

    private bool ShouldSpawnTube()
    {
        if (!_lastTube)
            return true;

        if (_lastTube.Bounds.max.x < _gameArea.Bounds.max.x)
            if (_lastTube.Bounds.max.x < (_gameArea.Bounds.max.x - _spaceBetweenTubes))
                return true;

        return false;
    }
}
