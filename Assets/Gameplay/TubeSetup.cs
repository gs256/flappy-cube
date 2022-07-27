using UnityEngine;

public class TubeSetup : MonoBehaviour
{
    private const float MaxSpacePosition = 0.3f;
    private const float MinSpacePosition = -0.3f;
    private const float MaxSpaceWidth = 0.5f;
    private const float MinSpaceWidth = 0.3f;

    [SerializeField]
    private MapTile _mapTile;

    private void Start()
    {
        Tube[] tubes = _mapTile.Tubes;

        foreach (var tube in tubes)
            SetupTube(tube);
    }

    private void SetupTube(Tube tube)
    {
        tube.SpacePosition = GetRandomSpacePosition();
        tube.SpaceWidth = GetRandomSpaceWidth();
    }

    private float GetRandomSpacePosition()
    {
        float value = Random.value;
        return MathUtils.Remap(value, 0f, 1f, MinSpacePosition, MaxSpacePosition);
    }

    private float GetRandomSpaceWidth()
    {
        float value = Random.value;
        return MathUtils.Remap(value, 0f, 1f, MinSpaceWidth, MaxSpaceWidth);
    }
}
