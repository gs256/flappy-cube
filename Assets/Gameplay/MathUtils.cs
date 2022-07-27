public static class MathUtils
{
    /// <summary>
    /// Maps x from [A; B] to [a; b]
    /// </summary>
    public static float Remap(float x, float A, float B, float a, float b)
    {
        var m = (b - a) / (B - A);
        var c = a - m * A;
        return m * x + c;
    }
}
