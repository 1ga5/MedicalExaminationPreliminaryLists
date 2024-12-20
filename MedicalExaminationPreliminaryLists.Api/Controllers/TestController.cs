using MedicalExaminationPreliminaryLists.Data.Models;
using MedicalExaminationPreliminaryLists.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationPreliminaryLists.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IPersonRepository _repository;

        public TestController(IPersonRepository repository) 
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> Test()
        {
            var testPeople = new List<Person>
            {
                new Person
                {
                    PersonId = "1",
                    Surname = "Иванов",
                    Name1 = "Иван",
                    Name2 = "Иванович",
                    Sex = 1,
                    Birthday = new DateTime(1980, 1, 15),
                    SNILS = "123-456-789 00",
                    ENP = "1111111111111111",
                    IsBad = false,
                    Hash = "hash1"
                },
                new Person
                {
                    PersonId = "2",
                    Surname = "Петров",
                    Name1 = "Петр",
                    Name2 = "Петрович",
                    Sex = 1,
                    Birthday = new DateTime(1990, 6, 20),
                    SNILS = "234-567-890 01",
                    ENP = "2222222222222222",
                    IsBad = true,
                    Hash = "hash2"
                },
                new Person
                {
                    PersonId = "3",
                    Surname = "Сидорова",
                    Name1 = "Анна",
                    Name2 = "Александровна",
                    Sex = 2,
                    Birthday = new DateTime(1985, 11, 5),
                    SNILS = "345-678-901 02",
                    ENP = "3333333333333333",
                    IsBad = false,
                    Hash = "hash3"
                },
                new Person
                {
                    PersonId = "4",
                    Surname = "Тестович",
                    Name1 = "Тест",
                    Name2 = "Тестович",
                    Sex = 1,
                    Birthday = new DateTime(2000, 1, 1),
                    SNILS = "000-000-000 00",
                    ENP = "0000000000000000",
                    IsBad = false,
                    Hash = "test-hash"
                }
            };

            testPeople[3].Id = Guid.Empty;
            foreach (Person p in testPeople)
            {
                _repository.Add(p);
            }

            await _repository.SaveChangesAsync();
            return Ok();
        }
    }
}
