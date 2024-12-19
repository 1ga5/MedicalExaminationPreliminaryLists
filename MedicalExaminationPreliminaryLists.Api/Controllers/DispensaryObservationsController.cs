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
        private readonly IDispensaryObservationRepository _dnRepository;
        private readonly IZAPRepository _zapRepository;

        public DispensaryObservationsController(IDispensaryObservationRepository dnRepository, IZAPRepository zapRepository)
        {
            _dnRepository = dnRepository;
            _zapRepository = zapRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DispensaryObservationModel>>> GetAll()
        {
            var DNs = await _dnRepository.GetAll().ToListAsync();

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
            var dn = await _dnRepository.GetByKeyAsync(id);

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
            var DNs = _dnRepository.FindBy(z => z.ZAPId == id);

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

        [HttpGet("file/{id}")]
        public async Task<ActionResult<List<DispensaryObservationModel>>> GetByFileId(Guid id)
        {
            var zaps = _zapRepository.FindBy(z => z.UploadFileId == id);

            var DNs = _dnRepository.FindBy(ds => zaps.Contains(ds.ZAP));

            var DNsDTO = DNs.Select(dn => new DispensaryObservationModel
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
            });

            return Ok(DNsDTO);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<ZAPModel>>> Update(int id, DispensaryObservationModel dnModel)
        {
            var dn = await _dnRepository.GetByKeyAsync(id);

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


            await _dnRepository.SaveChangesAsync();

            dnModel.Id = dn.Id;

            return Ok(dnModel);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<List<UploadFile>>> Delete(int id)
        {
            var dn = await _dnRepository.GetByKeyAsync(id);

            if (dn == null)
            {
                return NotFound();
            }

            // TODO: Подвязать пользователя
            await _dnRepository.VirtualDelete(dn, 0);
            await _dnRepository.SaveChangesAsync();

            return Ok("Успешно удалено");
        }
    }
}
