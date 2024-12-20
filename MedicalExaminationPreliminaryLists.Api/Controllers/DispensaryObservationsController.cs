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
    public class DispensaryObservationsController : ControllerBase
    {
        private readonly IDispensaryObservationRepository _repository;

        public DispensaryObservationsController(IDispensaryObservationRepository dnRepository, IZAPRepository zapRepository)
        {
            _repository = dnRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DispensaryObservationModel>>> GetAll()
        {
            var DNs = await _repository.GetAll().ToListAsync();

            var DNsDTO = DNs.Select(dn => new DispensaryObservationModel
            {
                Number = dn.Number,
                MedProfileId = dn.MedProfileId,
                LpuType = dn.LpuType,
                DiagnosisCode = dn.DiagnosisCode,
                BeginDate = dn.BeginDate,
                EndDate = dn.EndDate,
                EndReason = dn.EndReason
            });

            return Ok(DNsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DispensaryObservationModel>> Get(int id)
        {
            var dn = await _repository.GetByKeyAsync(id);

            if (dn == null)
            {
                return NotFound();
            }

            var dnDTO = new DispensaryObservationModel
            {
                Number = dn.Number,
                MedProfileId = dn.MedProfileId,
                LpuType = dn.LpuType,
                DiagnosisCode = dn.DiagnosisCode,
                BeginDate = dn.BeginDate,
                EndDate = dn.EndDate,
                EndReason = dn.EndReason
            };

            return Ok(dnDTO);
        }

        [HttpGet("zap/{id}")]
        public async Task<ActionResult<ZAPModel>> GetByZapId(Guid id)
        {
            var DNs = _repository.FindBy(z => z.ZAPId == id);

            var DNsDTO = DNs.Select(dn => new DispensaryObservationModel
            {
                Number = dn.Number,
                MedProfileId = dn.MedProfileId,
                LpuType = dn.LpuType,
                DiagnosisCode = dn.DiagnosisCode,
                BeginDate = dn.BeginDate,
                EndDate = dn.EndDate,
                EndReason = dn.EndReason
            });

            return Ok(DNsDTO);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ZAPModel>>> Update(int id, DispensaryObservationModel dnModel)
        {
            var dn = await _repository.GetByKeyAsync(id);

            if (dn == null)
            {
                return NotFound();
            }

            dn.Number = dnModel.Number;
            dn.MedProfileId = dnModel.MedProfileId;
            dn.LpuType = dnModel.LpuType;
            dn.DiagnosisCode = dnModel.DiagnosisCode;
            dn.BeginDate = dnModel.BeginDate;
            dn.EndDate = dnModel.EndDate;
            dn.EndReason = dnModel.EndReason;


            await _repository.SaveChangesAsync();

            dnModel.Id = dn.Id;

            return Ok(dnModel);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UploadFile>>> Delete(int id)
        {
            var dn = await _repository.GetByKeyAsync(id);

            if (dn == null)
            {
                return NotFound();
            }

            // TODO: Подвязать пользователя
            await _repository.VirtualDelete(dn, 0);
            await _repository.SaveChangesAsync();

            return Ok("Успешно удалено");
        }
    }
}
