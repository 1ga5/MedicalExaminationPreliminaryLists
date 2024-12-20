using MedicalExaminationPreliminaryLists.Api.Application.Mappers;
using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Infrastructure.Repositories;
using MedicalExaminationPreliminaryLists.Share.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalExaminationPreliminaryLists.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ZapsController : ControllerBase
    {
        private readonly IZAPRepository _repository;
        private readonly IPersonRepository _personRepository;

        public ZapsController(IZAPRepository repository, IPersonRepository personRepository)
        {
            _repository = repository;
            _personRepository = personRepository;
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

        [HttpGet("file/{id}")]
        public async Task<ActionResult<ZAPModel>> GetByFileId(Guid id)
        {
            var zaps = _repository.FindBy(z => z.UploadFileId == id).Include(z => z.Dispenses).ToList();

            var zapsDTO = zaps.Select(z => new ZAPModel
            {
                Id = z.Id,
                ZAPNumber = z.ZAPNumber,
                Year = z.Year,
                Surname = z.Surname,
                Name1 = z.Name1,
                Name2 = z.Name2,
                Birthday = z.Birthday,
                TelephoneNumber = z.TelephoneNumber,
                Dispenses = z.Dispenses.Select(dn => new DispensaryObservationModel
                {
                    Id = dn.Id,
                    Number = dn.Number,
                    MedProfileId = dn.MedProfileId,
                    LpuType = dn.LpuType,
                    DiagnosisCode = dn.DiagnosisCode,
                    BeginDate = dn.BeginDate,
                    EndDate = dn.EndDate,
                    EndReason = dn.EndReason,
                    ZAPId = dn.ZAPId
                }).ToList()
            });

            return Ok(zapsDTO);
        }

        [HttpPost]
        public async Task<ActionResult<ZAPModel>> Add(ZAPModel zapDTO)
        {
            try
            {
                ZAP zap = new ZAP
                {
                    ZAPNumber = zapDTO.ZAPNumber,
                    Year = zapDTO.Year,
                    Surname = zapDTO.Surname,
                    Name1 = zapDTO.Name1,
                    Name2 = zapDTO.Name2,
                    Birthday = zapDTO.Birthday,
                    TelephoneNumber = zapDTO.TelephoneNumber,
                    UploadFileId = zapDTO.UploadFileId
                };

                zap.PersonId = _personRepository.First(p =>
                        p.Surname == zap.Surname && p.Name1 == zap.Name1 && p.Name2 == zap.Name2 && p.Birthday == zap.Birthday)?.Id ?? Guid.Empty;

                _repository.Add(zap);
                await _repository.SaveChangesAsync();

                zapDTO.Id = zap.Id;

                return Ok(zapDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UploadFile>>> Delete(Guid id)
        {
            var zap = await _repository.GetByKeyAsync(id);

            if (zap == null)
            {
                return NotFound();
            }

            // TODO: Подвязать пользователя
            await _repository.VirtualDelete(zap, 0);
            await _repository.SaveChangesAsync();

            return Ok("Успешно удалено");
        }
    }
}
