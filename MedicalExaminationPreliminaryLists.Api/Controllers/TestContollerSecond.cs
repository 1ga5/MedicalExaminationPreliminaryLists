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
        private readonly IMedProfileRepository _repository;

        public TestContollerSecond(IMedProfileRepository repository)
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
            List<MedProfile> newDictionariesList = reader.ReadFromXml(filePath);

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
                var dictionary = new MedProfile
                {
                    Id = newDictionary.Id,
                    Code = newDictionary.Code,
                    Name = newDictionary.Name,
                    BeginDate = newDictionary.BeginDate,
                    EndDate = newDictionary.EndDate
                };
                _repository.Add(dictionary);
            }
            await _repository.SaveChangesAsync();

            var newDictionaries = await _repository.GetAll().ToListAsync();

        

            return Ok(newDictionaries);
        }
    }
}
