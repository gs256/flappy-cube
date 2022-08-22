using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    private PlayerSpawner _playerSpawner;

    [SerializeField]
    private TubeManager _tubeManager;

    private Player _player;

    private void Start()
    {
        _player = _playerSpawner.Spawn();
        _tubeManager.Run();
        _player.Crashed += OnPlayerCrashed;
    }

    private void OnDestroy()
    {
        _player.Crashed -= OnPlayerCrashed;
    }

    private void OnPlayerCrashed()
    {
        StopLevel();
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
