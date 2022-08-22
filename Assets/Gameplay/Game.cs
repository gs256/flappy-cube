using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    private PlayerSpawner _playerSpawner;

    [SerializeField]
    private TubeManager _tubeManager;

    [SerializeField]
    private GameUi _gameUi;

    private Player _player;

    private void Start()
    {
        InitializePlayer();
        InitializeUi();
    }

    private void OnDestroy()
    {
        DeinitializePlayer();
        DeinitializeUi();
    }

    private void InitializePlayer()
    {
        _player = _playerSpawner.Spawn();
        _player.Crashed += OnPlayerCrashed;
    }

    private void DeinitializePlayer()
    {
        if (_player)
            _player.Crashed -= OnPlayerCrashed;
    }

    private void InitializeUi()
    {
        _gameUi.StartClicked += StartLevel;
        _gameUi.RestartClicked += ReloadLevel;
        _gameUi.ShowStartUi();
    }

    private void DeinitializeUi()
    {
        _gameUi.StartClicked -= StartLevel;
        _gameUi.RestartClicked -= ReloadLevel;
    }

    private void OnPlayerCrashed()
    {
        StopLevel();
        _gameUi.ShowGameOverUi();
    }

    private void StartLevel()
    {
        _tubeManager.Run();
    }

    private void StopLevel()
    {
        _tubeManager.Stop();
    }

    private void ReloadLevel()
    {
        Debug.Log("Crashed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
