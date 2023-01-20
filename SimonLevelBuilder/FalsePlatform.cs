[Serializable]
public class FalsePlatform : PlatformBase
{
    public FalsePlatform() { }

    public FalsePlatform(Vector2 start, Vector2 end) : base(start, end)
    {
        ColorName = "Gray";
        col = Raylib_cs.Color.GRAY;
        HasHitbox = false;
    }
}
