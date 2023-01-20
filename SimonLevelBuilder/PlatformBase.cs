using System.Text.Json.Serialization;
using Raylib_cs;

[Serializable]
public abstract class PlatformBase
{
    //These are most often used, makes it so that you change the ones that matter
    [JsonPropertyName("Hitbox")]
    public bool HasHitbox { get; set; } = true;
    [JsonPropertyName("Damaging")]
    public bool Damages { get; set; } = false;
    [JsonPropertyName("Jump boost")]
    public bool JumpBoost { get; set; } = false;
    [JsonPropertyName("Speed boost")]
    public bool SpeedBoost { get; set; } = false;
    [JsonPropertyName("Decaying")]
    public bool Decaying { get; set; } = false;
    [JsonPropertyName("Color")]
    public string ColorName { get; set; }
    [JsonPropertyName("Start X")]
    public int StartX { get; set; }
    [JsonPropertyName("End X")]
    public int Width { get; set; }
    [JsonPropertyName("Start Y")]
    public int StartY { get; set; }
    [JsonPropertyName("End Y")]
    public int Height { get; set; }

    public Vector2 EndPosition;
    public Vector2 StartPosition;
    public Rectangle rectangle;
    public Color col;

    public PlatformBase()
    {

    }

    public PlatformBase(Vector2 start, Vector2 end)
    {
        Vector2 highValues = new(Math.Max(start.X, end.X), Math.Max(start.Y, end.Y));
        Vector2 lowValues = new(Math.Min(start.X, end.X), Math.Min(start.Y, end.Y));

        StartPosition = lowValues;
        EndPosition = highValues;

        StartX = (int)lowValues.X;
        Width = (int)highValues.X;

        StartY = (int)lowValues.Y;
        Height = (int)highValues.Y;

        rectangle = new(lowValues.X, lowValues.Y, highValues.X - lowValues.X, highValues.Y - lowValues.Y);
    }

    public void Render(Vector2 cameraOffset)
    {
        Rectangle temp = new(rectangle.x - cameraOffset.X, rectangle.y - cameraOffset.Y, rectangle.width, rectangle.height);
        Raylib.DrawRectangleRec(temp, col);
    }
}
