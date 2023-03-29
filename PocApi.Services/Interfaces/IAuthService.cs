using PocApi.DTOs;

namespace PocApi.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponseDTO<UserToInsertDTO>> Register(UserToInsertDTO userDTO);
        Task<ServiceResponseDTO<string>> Login(UserLoginDTO userLoginDTO);
    }
}
