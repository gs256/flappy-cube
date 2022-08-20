using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public event Action<Player> Crashed;

    [SerializeField]
    private PlayerCollision _collision;

    private void Start()
    {
        _collision.TriggerEnter += OnCrashed;
    }

    private void OnDestroy()
    {
        _collision.TriggerEnter += OnCrashed;
    }

    private void OnCrashed(Collider other)
        => Crashed?.Invoke(this);
}
