using UnityEngine;

public class TubeRemover : MonoBehaviour
{
    [SerializeField]
    private TubeHolder _tubeHolder;

    [SerializeField]
    private CubeBounds _gameArea;

    private void Update()
    {
        if (_tubeHolder.Objects.Count > 0 && _tubeHolder.Objects[0].Bounds.max.x < _gameArea.Bounds.min.x)
        {
            Tube first = _tubeHolder.PopFirst();
            Destroy(first.gameObject);
        }
    }
}
