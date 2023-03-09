using PocApi.DTOs;

namespace PocApi.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<UserDTO> GetByEmail (string email);
        Task<int> Insert(UserDTO userDTO);
        Task<UserDTO> Update(UserDTO userDTO);
    }
}
