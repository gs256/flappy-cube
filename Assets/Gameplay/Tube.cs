using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField]
    private GameObject _topPart;

    [SerializeField]
    private GameObject _bottomPart;

    [Space]
    [SerializeField]
    [Range(-0.5f, 0.5f)]
    private float _spacePosition;

    [SerializeField]
    [Range(0, 1)]
    private float _spaceWidth;

    [SerializeField]
    private CubeBounds _bounds;

    public Bounds Bounds => _bounds.Bounds;

    public float SpacePosition
    {
        get => _spacePosition;
        set
        {
            _spacePosition = Mathf.Clamp(value, -0.5f, 0.5f);
            float offset = 0.5f + _spaceWidth / 2f;
            _topPart.transform.localPosition = Vector3.up * (_spacePosition + offset);
            _bottomPart.transform.localPosition = Vector3.up * (_spacePosition - offset);
        }
    }

    public float SpaceWidth
    {
        get => _spaceWidth;
        set
        {
            _spaceWidth = value;
            SpacePosition = _spacePosition;
        }
    }

    private void OnValidate()
    {
        SpacePosition = _spacePosition;
        SpaceWidth = _spaceWidth;
    }
}
