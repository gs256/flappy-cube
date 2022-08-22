using UnityEngine;

public class TubeSpawner : ITickHandler
{
    private readonly ITubeFactory _tubeFactory;
    private readonly TubeHolder _tubeHolder;
    private readonly CubeBounds _gameArea;
    private float _spaceBetweenTubes;

    private readonly TubeSetup _tubeSetup = new TubeSetup();
    private Tube _lastTube;
    private bool _enabledSpawning;

    public TubeSpawner(ITubeFactory tubeFactory, TubeHolder tubeHolder, CubeBounds gameArea, float spaceBetweenTubes)
    {
        _tubeFactory = tubeFactory;
        _tubeHolder = tubeHolder;
        _gameArea = gameArea;
        _spaceBetweenTubes = spaceBetweenTubes;
    }

    public void Tick(float deltaTime)
    {
        if (ShouldSpawnTube())
            SpawnTube();
    }

    public void StartSpawning()
    {
        _enabledSpawning = true;
    }

    public void StopSpawning()
    {
        _enabledSpawning = false;
    }

    public void SpawnTube()
    {
        Tube tubePrefab = _tubeFactory.GetPrefab();
        Bounds bounds = _gameArea.Bounds;
        var tubePosition = new Vector3(bounds.max.x, bounds.center.y, bounds.center.z);

        Tube tube = GameObject.Instantiate(tubePrefab, tubePosition, Quaternion.identity);
        _tubeSetup.SetupTube(tube);
        _lastTube = tube;
        _tubeHolder.Add(tube);
    }

    private bool ShouldSpawnTube()
    {
        if (!_enabledSpawning)
            return false;

        if (!_lastTube)
            return true;

        if (_lastTube.Bounds.max.x < _gameArea.Bounds.max.x)
            if (_lastTube.Bounds.max.x < (_gameArea.Bounds.max.x - _spaceBetweenTubes))
                return true;

        return false;
    }
}
