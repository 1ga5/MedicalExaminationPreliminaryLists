using MedicalExaminationPreliminaryLists.Infrastructure.Common;
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
        private readonly IDispensaryObservationRepository _dsRepository;
        private readonly IZAPRepository _zapRepository;

        public DispensaryObservationsController(IDispensaryObservationRepository dsRepository, IZAPRepository zapRepository)
        {
            _dsRepository = dsRepository;
            _zapRepository = zapRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<DispensaryObservationModel>>> GetAll()
        {
            var DNs = await _dsRepository.GetAll().ToListAsync();

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
            var dn = await _dsRepository.GetByKeyAsync(id);

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
            var DNs = _dsRepository.FindBy(z => z.ZAPId == id);

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

            var DNs = _dsRepository.FindBy(ds => zaps.Contains(ds.ZAP));

            var DNsDTO = DNs.Select(dn => new DispensaryObservationModel
            {
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
    }
}
