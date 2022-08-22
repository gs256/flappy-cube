using UnityEngine;

public class TubeRemover : ITickHandler
{
    private readonly TubeHolder _tubeHolder;
    private readonly CubeBounds _gameArea;

    public TubeRemover(TubeHolder tubeHolder, CubeBounds gameArea)
    {
        _tubeHolder = tubeHolder;
        _gameArea = gameArea;
    }

    public void Tick(float deltaTime)
    {
        if (_tubeHolder.Objects.Count > 0 && _tubeHolder.Objects[0].Bounds.max.x < _gameArea.Bounds.min.x)
        {
            Tube first = _tubeHolder.PopFirst();
            GameObject.Destroy(first.gameObject);
        }
    }
}
