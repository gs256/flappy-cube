using UnityEngine;

public class TubeManager : MonoBehaviour
{
    [SerializeField]
    private TubeFactory _tubeFactory;

    [SerializeField]
    private CubeBounds _gameArea;

    [Space]
    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _spaceBetweenTubes;

    private TubeHolder _tubeHolder;
    private TubeSpawner _tubeSpawner;
    private TubeRemover _tubeRemover;
    private TubeShift _tubeShift;
    private bool _isRunning;

    private void Awake()
    {
        _tubeHolder = new TubeHolder();
        _tubeShift = new TubeShift(_tubeHolder, _speed);
        _tubeSpawner = new TubeSpawner(_tubeFactory, _tubeHolder, _gameArea, _spaceBetweenTubes);
        _tubeRemover = new TubeRemover(_tubeHolder, _gameArea);
    }

    private void Update()
    {
        if (_isRunning)
        {
            _tubeShift.Tick(Time.deltaTime);
            _tubeSpawner.Tick(Time.deltaTime);
            _tubeRemover.Tick(Time.deltaTime);
        }
    }

    public void Run()
    {
        _isRunning = true;
        _tubeSpawner.StartSpawning();
    }

    public void Stop()
    {
        _isRunning = false;
        _tubeSpawner.StopSpawning();
    }
}
