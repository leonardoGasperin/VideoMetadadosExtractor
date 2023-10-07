using Entities;

namespace Interfaces;

public interface IMetadataExtractor
{
    public Task<VideoMetadata> ExtractMetadata(Stream videoStream);
}
