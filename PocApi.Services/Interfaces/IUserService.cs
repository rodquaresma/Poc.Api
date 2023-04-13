using PocApi.DTOs;
using PocApi.DTOs.Filters;

namespace PocApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<ServiceResponseDTO<bool>> Update(UserDTO userDTO);
        Task<ServiceResponseDTO<bool>> Delete(UserDTO userDTO);
        Task<ServiceResponseDTO<List<UserDTO>>> GetAll(UserFilterDTO userFilterDTO);
    }
}
