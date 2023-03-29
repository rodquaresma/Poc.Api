using AutoMapper;
using PocApi.Business.Interfaces;
using PocApi.Data.Interfaces;
using PocApi.Data.Repositories;
using PocApi.DTOs;
using PocApi.Entities;

namespace PocApi.Business
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserBusiness(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            User user = await _userRepository.GetByEmail(email);         
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            
            return userDTO;
        }

        public async Task<int> Insert(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            return await _userRepository.Insert(user);
        }

        public Task<bool> Update(UserDTO userDTO)
        {
            throw new NotImplementedException("Chegamos na business!!!");
        }
    }
}
