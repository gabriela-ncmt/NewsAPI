
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly ILogger<UploadController> _logger;

        public UploadController(ILogger<UploadController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Upload(IFormFile image)
        {
            try
            {
                if (image == null) return null;

                using (var stream = new FileStream(Path.Combine("Imagens", image.FileName), FileMode.Create))
                {
                    image.CopyTo(stream);
                }
                return Ok(new
                {
                    mensagem = "Imagem salva com sucesso!",
                    urlImagem = $"http://localhost:7221/imgs/{image.FileName}"
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro no upload: " + ex.Message);
            }
        }
    }
}
