using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VideoMetadadosExtractor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult VideoExtractor(IFormFile videoFile)
        {
            if (videoFile != null)
            {
                string[] allowedVideoExtensions = { ".mp4", ".avi", ".mov" };
                string fileExtension = Path.GetExtension(videoFile.FileName);

                if (allowedVideoExtensions.Contains(fileExtension.ToLower()))
                {
                    // Extrair informa��es aqui
                }
                else
                {
                    return BadRequest("Por favor, envie um arquivo de v�deo v�lido.");
                }
            }
            else
            {
                return BadRequest("Nenhum arquivo de v�deo enviado.");
            }


            return StatusCode(200);
        }
    }
}
