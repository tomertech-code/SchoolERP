using Microsoft.AspNetCore.Mvc;
using SchoolERP.BLL.Services;

namespace SchoolERP.UI.Controllers
{
    public class FileUploadController : Controller
    {
        private readonly FileUploadService _fileUploadService;

        public FileUploadController(FileUploadService fileUploadService)
        {
            _fileUploadService = fileUploadService;
        }

        // Action to upload a file
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var result = await _fileUploadService.UploadFileAsync(file);
            return Ok(result);  // You can return the result or handle as needed
        }
    }
}
