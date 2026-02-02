/// <summary>Logging configuration.</summary>
public sealed class LoggingOptions
{
    public bool Enabled { get; init; }
    public string FilePath { get; init; } = "spider.log";
}