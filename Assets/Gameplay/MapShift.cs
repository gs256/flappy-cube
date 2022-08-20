using UnityEngine;

public class MapShift : MonoBehaviour
{
    [SerializeField]
    private TubeHolder _tubeHolder;

    [Space]
    [SerializeField]
    private float _speed;

    private void Update()
    {
        var translation = Vector3.left * _speed * Time.deltaTime;

        foreach (var obj in _tubeHolder.Objects)
            obj.transform.Translate(translation);
    }
}
