using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Infrastructure.Repositories;
using MedicalExaminationPreliminaryLists.Share.DTOs;
using MedicalExaminationPreliminaryLists.UI.Components.Pages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MedicalExaminationPreliminaryLists.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
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
                TelephoneNumber = zap.TelephoneNumber,
                UploadFileId = zap.UploadFileId
            };

            return Ok(zapDTO);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ZAPModel>>> Update(Guid id, ZAPModel zapDTO)
        {
            var zap = await _repository.GetByKeyAsync(id);

            if (zap == null)
            {
                return NotFound();
            }

            zap.ZAPNumber = zapDTO.ZAPNumber;
            zap.Year = zapDTO.Year;
            zap.Surname = zapDTO.Surname;
            zap.Name1 = zapDTO.Name1;
            zap.Name2 = zapDTO.Name2;
            zap.Birthday = zapDTO.Birthday;
            zap.TelephoneNumber = zapDTO.TelephoneNumber;


            await _repository.SaveChangesAsync();

            zapDTO.Id = zap.Id;

            return Ok(zap);
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
