[Serializable]
public class SpeedPlatform : PlatformBase
{
    public SpeedPlatform() { }

    public SpeedPlatform(Vector2 start, Vector2 end) : base(start, end)
    {
        ColorName = "Blue";
        col = Raylib_cs.Color.BLUE;
        SpeedBoost = true;
    }
}
