using Entities;
using Interfaces;
using Xabe.FFmpeg;


namespace Services;

public class MetadataExtractorService : IMetadataExtractor
{
    public async Task<VideoMetadata> ExtractMetadata(Stream videoStream)
    {
        var tempFilePath = Path.GetTempFileName();
        using (var fileStream = File.OpenWrite(tempFilePath))
        {
            await videoStream.CopyToAsync(fileStream);
        }

        try
        {
            var mediaInfo = await FFmpeg.GetMediaInfo(tempFilePath);

            var videoStreamInfo = mediaInfo.VideoStreams.FirstOrDefault();

            if (videoStreamInfo != null)
            {
                var metadata = new VideoMetadata
                {
                    DurationInSeconds = (long)videoStreamInfo.Duration.TotalSeconds,
                    Width = videoStreamInfo.Width,
                    Height = videoStreamInfo.Height,
                    FrameRate = videoStreamInfo.Framerate.ToString(),
                    VideoCodec = videoStreamInfo.Codec,
                    VideoBitrate = videoStreamInfo.Bitrate,
                    AudioCodec = mediaInfo.AudioStreams.FirstOrDefault()?.Codec,
                    AudioChannels = mediaInfo.AudioStreams.FirstOrDefault()?.Channels ?? 0,
                    AudioSampleRate = mediaInfo.AudioStreams.FirstOrDefault()?.SampleRate ?? 0,
                    AudioBitrate = mediaInfo.AudioStreams.FirstOrDefault()?.Bitrate ?? 0,
                    AudioLanguage = mediaInfo.AudioStreams.FirstOrDefault()?.Language ?? "No espefic language founded",
                    HasSubtitles = mediaInfo.SubtitleStreams.Any(),
                    AspectRatio = mediaInfo.VideoStreams.FirstOrDefault()?.Ratio,
                    CreationDate = mediaInfo.CreationTime ?? DateTime.Now
                };

                return metadata;
            }
            else
            {
                throw new InvalidOperationException("O vídeo não contém informações de metadados de vídeo.");
            }
        }
        finally
        {
            File.Delete(tempFilePath);
        }
    }
}
