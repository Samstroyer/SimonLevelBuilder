[Serializable]
public class FalsePlatform : PlatformBase
{
    public FalsePlatform() { }

    public FalsePlatform(Vector2 start, Vector2 end) : base(start, end)
    {
        colorName = "Gray";
        col = Raylib_cs.Color.GRAY;
        HasHitbox = false;
    }
}
