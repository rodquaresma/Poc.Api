using PocApi.Business.Interfaces;
using PocApi.Data.Interfaces;
using PocApi.Data.Repositories;
using PocApi.DTOs;
using PocApi.Entities;

namespace PocApi.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            User user = await _userRepository.GetByEmail(email);

            if (user == null)
            {
                return null;
            }

            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = email
            };
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
