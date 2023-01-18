global using System.Numerics;
using Raylib_cs;

Builder b = new();

Setup();
Run();

void Setup()
{
    Raylib.InitWindow(1600, 800, "JumpMaster");
    Raylib.SetTargetFPS(60);
}

void Run()
{
    b.Start();
}