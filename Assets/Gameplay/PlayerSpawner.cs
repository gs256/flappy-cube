using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField]
    private Player _playerPrefab;

    [SerializeField]
    private Transform _playerSpawnPoint;

    public Player Spawn()
    {
        return Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
    }
}
