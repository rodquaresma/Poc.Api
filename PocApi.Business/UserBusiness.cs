using PocApi.Business.Interfaces;
using PocApi.DTOs;

namespace PocApi.Business
{
    public class UserBusiness : IUserBusiness
    {
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserDTO> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(UserDTO userDTO)
        {
            throw new NotImplementedException("Chegamos na business!!!");
        }
    }
}
