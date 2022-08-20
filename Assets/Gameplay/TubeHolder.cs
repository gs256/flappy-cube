using System;
using System.Collections.Generic;
using UnityEngine;

public class TubeHolder : MonoBehaviour
{
    public event Action<Tube> Added;

    public IReadOnlyList<Tube> Objects => _tubes;

    private List<Tube> _tubes = new List<Tube>();

    public void Add(Tube tube)
    {
        _tubes.Add(tube);
        Added?.Invoke(tube);
    }

    public Tube PopFirst()
    {
        Tube first = _tubes[0];
        _tubes.RemoveAt(0);
        return first;
    }
}
