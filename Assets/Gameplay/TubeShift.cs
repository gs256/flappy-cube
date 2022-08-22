using UnityEngine;

public class TubeShift : ITickHandler
{
    private readonly TubeHolder _tubeHolder;
    private float _speed;

    public TubeShift(TubeHolder tubeHolder, float speed)
    {
        _tubeHolder = tubeHolder;
        _speed = speed;
    }

    public void Tick(float deltaTime)
    {
        var translation = Vector3.left * _speed * deltaTime;

        foreach (var obj in _tubeHolder.Objects)
            obj.transform.Translate(translation);
    }
}
