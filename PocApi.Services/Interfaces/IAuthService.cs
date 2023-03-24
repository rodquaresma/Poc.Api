using PocApi.DTOs;

namespace PocApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponseDTO<UserDTO>> Register(UserDTO userDTO);
        Task<ServiceResponseDTO<string>> Login(UserLoginDTO userLoginDTO);
    }
}
