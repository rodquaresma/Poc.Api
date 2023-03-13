using PocApi.DTOs;

namespace PocApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponseDTO<bool>> Update(UserDTO userDTO);
        Task<ServiceResponseDTO<bool>> Delete(UserDTO userDTO);
    }
}
