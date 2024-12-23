using MedicalCareForm.Api.Services;
using MedicalExaminationPreliminaryLists.Data.Models.Dictionaries;
using MedicalExaminationPreliminaryLists.Infrastructure.Common;
using MedicalExaminationPreliminaryLists.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TFOMSUploadServer.Infrastructure.Repositories;

namespace MedicalExaminationPreliminaryLists.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestContollerSecond : ControllerBase
    {
        private readonly IDiagnosisRepository _repository;

        public TestContollerSecond(IDiagnosisRepository repository)
        {
            _repository = repository;
        }
        [HttpPost("upload")]
        public async Task<ActionResult<List<MedProfile>>> UploadFile(IFormFile file)
        {

            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Files", file.FileName);

            //Directory.CreateDirectory(Path.GetDirectoryName(filePath));

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            };

            MedicalCareFormReader reader = new();
            List<Diagnosis> newDictionariesList = reader.ReadFromXml(filePath);

            var oldDictionaries = await _repository.GetAll().ToListAsync();
            foreach (var oldDictionary in oldDictionaries)
            {
                var dictionaryToDelete = await _repository.GetByKeyAsync(oldDictionary.Id);
                if (dictionaryToDelete is not null)
                {
                    await _repository.VirtualDelete(dictionaryToDelete, 0);
                }
            }
            await _repository.SaveChangesAsync();

            foreach (var newDictionary in newDictionariesList)
            {
                var dictionary = new Diagnosis
                {
                    //Id = newDictionary.Id,
                    Code = newDictionary.Code,
                    Name = newDictionary.Name,
                    ParentId = newDictionary.ParentId,
                    IsActual = newDictionary.IsActual
                };
                _repository.Add(dictionary);
            }
            await _repository.SaveChangesAsync();

            var newDictionaries = await _repository.GetAll().ToListAsync();

        

            return Ok(newDictionaries);
        }
    }
}
