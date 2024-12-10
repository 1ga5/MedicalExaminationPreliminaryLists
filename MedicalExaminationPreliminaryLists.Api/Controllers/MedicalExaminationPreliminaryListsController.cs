using MedicalExaminationPreliminaryLists.Api.Application.Services;
using MedicalExaminationPreliminaryLists.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationPreliminaryLists.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class MedicalExaminationPreliminaryListsController : ControllerBase
    {
        private readonly IUploadService _service;

        public MedicalExaminationPreliminaryListsController(IUploadService service)
        {
            _service = service;
        }


        [HttpPost("upload")]
        public async Task<ActionResult> UploadFile(IFormFile file)
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", file.FileName);

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                };

                _service.UploadFile(filePath);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
