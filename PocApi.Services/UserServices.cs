using PocApi.DTOs;
using PocApi.Services.Interfaces;

namespace PocApi.Services
{
    public class UserServices : IUserService
    {
        public Task<ServiceResponseDTO<bool>> Delete(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponseDTO<UserDTO>> Update(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}