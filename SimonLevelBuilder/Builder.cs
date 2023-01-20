using System.Text.Json;
using Raylib_cs;

public class Builder
{
    Vector2 cameraOffset = new();
    Vector2 levelSize;
    Vector2 tempPosition;
    bool placing = false;

    PlatformBase current = new WalkingPlatform();
    PlatformContainer container = new();

    int index = 0;

    public Builder()
    {
        int tempX, tempY;
        Console.WriteLine("Enter Map Width:");
        tempX = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Map Height:");
        tempY = int.Parse(Console.ReadLine());

        levelSize = new(tempX, tempY);
    }

    public void Start()
    {
        while (!Raylib.WindowShouldClose())
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.WHITE);

            Raylib.DrawRectangle(0 - (int)cameraOffset.X, 0 - (int)cameraOffset.Y, (int)levelSize.X, (int)levelSize.Y, Color.BROWN);

            KeyboardKey key = (KeyboardKey)Raylib.GetKeyPressed();

            if (Raylib.IsMouseButtonPressed(MouseButton.MOUSE_BUTTON_LEFT)) Pressed();

            if (key == KeyboardKey.KEY_Z) Pop();

            if (key == KeyboardKey.KEY_LEFT) SwitchCurrent(-1);
            if (key == KeyboardKey.KEY_RIGHT) SwitchCurrent(1);

            if (key == KeyboardKey.KEY_S) Serialise();
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) Move(new(-10, 0));
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) Move(new(10, 0));
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) Move(new(0, -10));
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) Move(new(0, 10));

            List<PlatformBase> temp = new();
            temp.AddRange(container.fallingPlatforms);
            temp.AddRange(container.falsePlatforms);
            temp.AddRange(container.hurtingPlatforms);
            temp.AddRange(container.jumpPlatforms);
            temp.AddRange(container.speedPlatforms);
            temp.AddRange(container.walkingPlatforms);

            foreach (var p in temp)
            {
                p.Render(cameraOffset);
            }

            Raylib.EndDrawing();
        }
    }

    private void Move(Vector2 dir)
    {
        cameraOffset += dir;
        if (cameraOffset.X < 0) cameraOffset.X = 0;
        if (cameraOffset.Y < 0) cameraOffset.Y = 0;

        if (cameraOffset.X + Raylib.GetScreenWidth() > levelSize.X) cameraOffset.X = levelSize.X - Raylib.GetScreenWidth();
        if (cameraOffset.Y + Raylib.GetScreenHeight() > levelSize.Y) Console.WriteLine("test");//cameraOffset.Y = levelSize.Y - Raylib.GetScreenHeight();
    }

    private void Pop()
    {
        switch (index)
        {
            case 0:
                if (container.walkingPlatforms.Count <= 0) return;
                container.walkingPlatforms.Pop();
                break;
            case 1:
                if (container.speedPlatforms.Count <= 0) return;
                container.speedPlatforms.Pop();
                break;
            case 2:
                if (container.jumpPlatforms.Count <= 0) return;
                container.jumpPlatforms.Pop();
                break;
            case 3:
                if (container.hurtingPlatforms.Count <= 0) return;
                container.hurtingPlatforms.Pop();
                break;
            case 4:
                if (container.falsePlatforms.Count <= 0) return;
                container.falsePlatforms.Pop();
                break;
            case 5:
                if (container.fallingPlatforms.Count <= 0) return;
                container.fallingPlatforms.Pop();
                break;
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
                    container.walkingPlatforms.Push(new WalkingPlatform(tempPosition + cameraOffset, Raylib.GetMousePosition() + cameraOffset));
                    break;
                case 1:
                    container.speedPlatforms.Push(new SpeedPlatform(tempPosition + cameraOffset, Raylib.GetMousePosition() + cameraOffset));
                    break;
                case 2:
                    container.jumpPlatforms.Push(new JumpPlatform(tempPosition + cameraOffset, Raylib.GetMousePosition()));
                    break;
                case 3:
                    container.hurtingPlatforms.Push(new HurtingPlatform(tempPosition + cameraOffset, Raylib.GetMousePosition()));
                    break;
                case 4:
                    container.falsePlatforms.Push(new FalsePlatform(tempPosition + cameraOffset, Raylib.GetMousePosition()));
                    break;
                case 5:
                    container.fallingPlatforms.Push(new FallingPlatform(tempPosition + cameraOffset, Raylib.GetMousePosition()));
                    break;
            }
        }
    }

    public void Serialise()
    {
        JsonSerializerOptions options = new();
        options.WriteIndented = true;
        string json = JsonSerializer.Serialize<PlatformContainer>(container, options);
        File.WriteAllText("Level.json", json);
    }
}
