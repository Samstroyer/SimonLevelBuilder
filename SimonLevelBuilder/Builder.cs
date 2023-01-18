using System.Text.Json;
using Raylib_cs;

public class Builder
{
    Vector2 cameraOffset;
    Vector2 levelSize;
    Vector2 tempPosition;
    bool placing = false;

    Stack<PlatformBase> platforms = new();

    PlatformBase current = new WalkingPlatform();

    int index = 0;

    public Builder()
    {
        // int tempX, tempY;
        // Console.WriteLine("Enter Map Width:");
        // tempX = int.Parse(Console.ReadLine());
        // Console.WriteLine("Enter Map Height:");
        // tempY = int.Parse(Console.ReadLine());

        // levelSize = new(tempX, tempY);
    }

    public void Start()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)) Pressed();

            if (key == KeyboardKey.KEY_Z && platforms.Count > 0) platforms.Pop();

            if (key == KeyboardKey.KEY_LEFT) SwitchCurrent(-1);
            if (key == KeyboardKey.KEY_RIGHT) SwitchCurrent(1);

            if (key == KeyboardKey.KEY_S) Serialise();

            foreach (var platform in platforms)
            {
                platform.Render();
            }

            Raylib.EndDrawing();
        }
    }

    private void SwitchCurrent(int change)
    {
        index += change;
        if (index > 5) index = 0;
        if (index < 0) index = 4;
    }

    public void Pressed()
    {
        if (!placing)
        {
            tempPosition = Raylib.GetMousePosition();
            placing = !placing;
        }
        else
        {
            placing = !placing;
            switch (index)
            {
                case 0:
                    platforms.Push(new WalkingPlatform(tempPosition, Raylib.GetMousePosition()));
                    break;
                case 1:
                    platforms.Push(new SpeedPlatform(tempPosition, Raylib.GetMousePosition()));
                    break;
                case 2:
                    platforms.Push(new JumpPlatform(tempPosition, Raylib.GetMousePosition()));
                    break;
                case 3:
                    platforms.Push(new HurtingPlatform(tempPosition, Raylib.GetMousePosition()));
                    break;
                case 4:
                    platforms.Push(new FalsePlatform(tempPosition, Raylib.GetMousePosition()));
                    break;
                case 5:
                    platforms.Push(new FallingPlatform(tempPosition, Raylib.GetMousePosition()));
                    break;
            }
        }
    }

    public void Serialise()
    {
        JsonSerializerOptions options = new();
        options.WriteIndented = true;
        string json = JsonSerializer.Serialize<List<PlatformBase>>(platforms.ToList(), options);
        File.WriteAllText("Level.json", json);
    }
}
