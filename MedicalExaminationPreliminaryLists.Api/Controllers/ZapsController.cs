using MedicalExaminationPreliminaryLists.Infrastructure.Repositories;
using MedicalExaminationPreliminaryLists.Share.DTOs;
using MedicalExaminationPreliminaryLists.UI.Components.Pages;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MedicalExaminationPreliminaryLists.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ZapsController : ControllerBase
    {
        private readonly IZAPRepository _repository;

        public ZapsController(IZAPRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<ZAPModel>>> GetAll()
        {
            var zaps = await _repository.GetAll().ToListAsync();

            var zapsDTO = zaps.Select(z => new ZAPModel
            {
                Id = z.Id,
                ZAPNumber = z.ZAPNumber,
                Year = z.Year,
                Surname = z.Surname,
                Name1 = z.Name1,
                Name2 = z.Name2,
                Birthday = z.Birthday,
                TelephoneNumber = z.TelephoneNumber
            });

            return Ok(zapsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ZAPModel>> Get(Guid id)
        {
            var zap = await _repository.GetByKeyAsync(id);
            
            if (zap == null)
            {
                return NotFound();
            }

            var zapDTO = new ZAPModel
            {
                Id = zap.Id,
                ZAPNumber = zap.ZAPNumber,
                Year = zap.Year,
                Surname = zap.Surname,
                Name1 = zap.Name1,
                Name2 = zap.Name2,
                Birthday = zap.Birthday,
                TelephoneNumber = zap.TelephoneNumber
            };

            return Ok(zapDTO);
        }

        [HttpGet("file/{id}")]
        public async Task<ActionResult<ZAPModel>> GetByFileId(Guid id)
        {
            var zaps = _repository.FindBy(z => z.UploadFileId == id);

            var zapsDTO = zaps.Select(z => new ZAPModel
            {
                Id = z.Id,
                ZAPNumber = z.ZAPNumber,
                Year = z.Year,
                Surname = z.Surname,
                Name1 = z.Name1,
                Name2 = z.Name2,
                Birthday = z.Birthday,
                TelephoneNumber = z.TelephoneNumber
            });

            return Ok(zapsDTO);
        }
    }
}
