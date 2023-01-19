using System.Text.Json.Serialization;

public class PlatformContainer
{
    [JsonPropertyName("Falling Platforms")]
    public Stack<FallingPlatform> fallingPlatforms { get; set; } = new();

    [JsonPropertyName("False Platforms")]
    public Stack<FalsePlatform> falsePlatforms { get; set; } = new();

    [JsonPropertyName("Hurting Platforms")]
    public Stack<HurtingPlatform> hurtingPlatforms { get; set; } = new();

    [JsonPropertyName("Jump Boost Platforms")]
    public Stack<JumpPlatform> jumpPlatforms { get; set; } = new();

    [JsonPropertyName("Speed Platforms")]
    public Stack<SpeedPlatform> speedPlatforms { get; set; } = new();

    [JsonPropertyName("Walking Platforms")]
    public Stack<WalkingPlatform> walkingPlatforms { get; set; } = new();
}
