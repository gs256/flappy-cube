using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField]
    private PlayerSpawner _playerSpawner;

    private Player _player;

    private void Start()
    {
        _player = _playerSpawner.Spawn();
        _player.Crashed += ReloadLevel;
    }

    private void OnDestroy()
    {
        _player.Crashed -= ReloadLevel;
    }

    private void ReloadLevel()
    {
        Debug.Log("Crashed");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
