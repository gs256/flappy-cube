using System;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public event Action<Collider> TriggerEnter;

    private void OnTriggerEnter(Collider other)
    {
        TriggerEnter?.Invoke(other);
    }
}
