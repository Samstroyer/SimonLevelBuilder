[Serializable]
public class FallingPlatform : PlatformBase
{
    public FallingPlatform() { }

    public FallingPlatform(Vector2 start, Vector2 end) : base(start, end)
    {
        colorName = "Orange";
        col = Raylib_cs.Color.ORANGE;
        Decaying = true;
    }
}
