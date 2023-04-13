using AutoMapper;
using PocApi.Business.Interfaces;
using PocApi.Data.Interfaces;
using PocApi.Data.Repositories;
using PocApi.DTOs;
using PocApi.DTOs.Filters;
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
        public async Task<bool> Delete(int id)
        {
            User user = await _userRepository.GetById(id);

            if (user == null)
            {
                return false;
            }

            user.IsActive = false;
            user.UpdatedAt = DateTime.Now;
            return await _userRepository.Update(user);

        }

        public async Task<List<UserDTO>> GetAll(UserFilterDTO userFilterDTO)
        {
            List<User> users = await _userRepository.GetAll(userFilterDTO);
            List<UserDTO> userDTOs = _mapper.Map<List<UserDTO>>(users);

            return userDTOs;
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

        public async Task<bool> Update(UserDTO userDTO)
        {
            User user = _mapper.Map<User>(userDTO);
            return await _userRepository.Update(user);
        }
    }
}
