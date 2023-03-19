using PocApi.Business.Interfaces;
using PocApi.Data.Repositories;
using PocApi.DTOs;

namespace PocApi.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly UserRepository _userRepository;
        public UserBusiness(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
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
