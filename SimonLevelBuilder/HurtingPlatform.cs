[Serializable]
public class HurtingPlatform : PlatformBase
{
    public HurtingPlatform() { }

    public HurtingPlatform(Vector2 start, Vector2 end) : base(start, end)
    {
        colorName = "Red";
        col = Raylib_cs.Color.RED;
        Damages = true;
    }
}
