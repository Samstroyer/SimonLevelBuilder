[Serializable]
public class WalkingPlatform : PlatformBase
{
    public WalkingPlatform() { }

    public WalkingPlatform(Vector2 start, Vector2 end) : base(start, end)
    {
        ColorName = "Black";
        col = Raylib_cs.Color.BLACK;
    }
}
