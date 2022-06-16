using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using NotasWorkshop.Model.Entities;
using NotasWorkshop.Services.Services;

namespace NotasWorkshop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarberWorkController : ControllerBase
    {
        private readonly IFileManagerLogic _fileManagerLogic;
        public BarberWorkController(IFileManagerLogic fileManagerLogic , IConfiguration configuration)
        {
            _fileManagerLogic = fileManagerLogic;
        }
        [HttpGet]
        [Route("GetImagesJPG")]
        public async Task<IActionResult> Read(string fileName)
        {
            var imgData = await _fileManagerLogic.Read(fileName);
            return File(imgData, "image/jpg");
        }

        [Route("upload")]
        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] BarberWork model)
        {
            if (model.ImageFile != null)
            {
                var path = await _fileManagerLogic.Upload(model);
                return Ok(path);
            }
            return BadRequest("File to upload");
        }
    }
}
