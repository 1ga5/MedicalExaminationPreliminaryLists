using MedicalExaminationPreliminaryLists.Api.Application.Services;
using MedicalExaminationPreliminaryLists.Data.Models.Identity;
using MedicalExaminationPreliminaryLists.Share.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalExaminationPreliminaryLists.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _authService.Login(model);
                if (status == 0)
                    return BadRequest(message);
                return Ok(message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("registration")]
        public async Task<IActionResult> Register(RegistrationModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid payload");
                var (status, message) = await _authService.Registration(model, UserRoles.User);
                if (status == 0)
                {
                    Console.WriteLine("FFFF");
                    return BadRequest(message);
                }
                return CreatedAtAction(nameof(Register), model);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
