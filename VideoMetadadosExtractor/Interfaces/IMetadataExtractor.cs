using Entities;

namespace Interfaces;

public interface IMetadataExtractor
{
    public VideoMetadata ExtractMetadata(Stream videoStream);
}
