using Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VideoMetadadosExtractor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMetadataExtractor _metadataExtractor;

        public IndexModel(ILogger<IndexModel> logger, IMetadataExtractor metadataExtractor)
        {
            _logger = logger;
            _metadataExtractor = metadataExtractor;
        }

        public IActionResult OnPostVideoExtractor(IFormFile videoFile)
        {
            if (videoFile == null || videoFile.Length == 0)
            {
                return BadRequest("Nenhum arquivo de vídeo enviado.");
            }

            string[] allowedVideoExtensions = { ".mp4", ".avi", ".mov" };
            string fileExtension = Path.GetExtension(videoFile.FileName);

            if (!allowedVideoExtensions.Contains(fileExtension.ToLower()))
            {
                return BadRequest("Por favor, envie um arquivo de vídeo válido.");
            }

            try
            {
                var metaData = _metadataExtractor.ExtractMetadata(videoFile.OpenReadStream());

                return new JsonResult(new {metaData});
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao processar o vídeo: {ex.Message}");
            }
        }
    }
}
