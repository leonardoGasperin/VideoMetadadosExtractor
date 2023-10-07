namespace Entities;

public class VideoMetadata
{
    public long DurationInSeconds { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public string? FrameRate { get; set; }
    public string VideoCodec { get; set; }
    public long VideoBitrate { get; set; }
    public string? AudioCodec { get; set; }
    public int AudioChannels { get; set; }
    public int AudioSampleRate { get; set; }
    public long AudioBitrate { get; set; }
    public string AudioLanguage { get; set; }
    public bool HasSubtitles { get; set; }
    public string? AspectRatio { get; set; }
    public DateTime CreationDate { get; set; }
}
