using PocApi.DTOs;

namespace PocApi.Business.Interfaces
{
    public interface IUserBusiness
    {
        Task<UserDTO> GetByEmail (string email);
        Task<int> Insert(UserDTO userDTO);
        Task<bool> Update(UserDTO userDTO);
        Task<bool> Delete(int id);
    }
}
