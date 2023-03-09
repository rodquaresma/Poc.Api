using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocApi.DTOs;
using PocApi.Services.Interfaces;

namespace PocApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPut]
        [Route(nameof(Update))]
        
        public async Task<IActionResult> Update([FromBody] UserDTO userDTO)
        {
            ServiceResponseDTO<UserDTO> serviceResponseDTO = await _userService.Update(userDTO);
            return Ok(serviceResponseDTO);
        }

        [HttpDelete]
        [Route(nameof(Delete))]

        public async Task<IActionResult> Delete([FromBody] UserDTO userDTO)
        {
            ServiceResponseDTO<bool> serviceResponseDTO = await _userService.Delete(userDTO);
            return Ok(serviceResponseDTO);
        }
    }
}
