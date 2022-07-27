using System;
using System.Collections.Generic;
using UnityEngine;

public class MapTilePool : MonoBehaviour
{
    public event Action<MapTile> Added;

    public IReadOnlyList<MapTile> Objects => _tiles;

    private List<MapTile> _tiles = new List<MapTile>();

    public void Add(MapTile tile)
    {
        _tiles.Add(tile);
        Added?.Invoke(tile);
    }

    public MapTile PopFirst()
    {
        MapTile first = _tiles[0];
        _tiles.RemoveAt(0);
        return first;
    }
}