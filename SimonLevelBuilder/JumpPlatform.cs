[Serializable]
public class JumpPlatform : PlatformBase
{
    public JumpPlatform() { }

    public JumpPlatform(Vector2 start, Vector2 end) : base(start, end)
    {
        ColorName = "Green";
        col = Raylib_cs.Color.GREEN;
        JumpBoost = true;
    }
}
