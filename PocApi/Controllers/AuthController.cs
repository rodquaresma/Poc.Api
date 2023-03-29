using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocApi.DTOs;
using PocApi.Services.Interfaces;

namespace PocApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService= authService;
        }

        [HttpGet]
        [Route(nameof(Login))]

        public async Task<IActionResult> Login([FromQuery] UserLoginDTO userLoginDTO)
        {
            ServiceResponseDTO<string> serviceResponseDTO = await _authService.Login(userLoginDTO);

            return Ok(serviceResponseDTO);
        }

        [HttpPost]
        [Route(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] UserToInsertDTO userToInsertDTO)
        {
            ServiceResponseDTO<UserToInsertDTO> serviceResponseDTO = await _authService.Register(userToInsertDTO);

            return Ok(serviceResponseDTO);
        }
    }
}
