using PocApi.Business.Interfaces;
using PocApi.DTOs;
using PocApi.DTOs.Filters;
using PocApi.Services.Interfaces;
using PocApi.Shared.Messages;

namespace PocApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserBusiness _userBusiness;

        public UserService(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        public async Task<ServiceResponseDTO<bool>> Delete(UserDTO userDTO)
        {
            ServiceResponseDTO<bool> serviceResponseDTO = new ServiceResponseDTO<bool>();
            try
            {
                serviceResponseDTO.Data = await _userBusiness.Delete(userDTO.Id);
            }
            catch (Exception ex)
            {
                serviceResponseDTO.IsSucess = false;
                serviceResponseDTO.Message = ConstantMessages.FailureMessage(ex.GetBaseException().Message);
            }

            return serviceResponseDTO;
        }

        public async Task<ServiceResponseDTO<List<UserDTO>>> GetAll(UserFilterDTO userFilterDTO)
        {
            ServiceResponseDTO<List<UserDTO>> serviceResponseDTO = new ServiceResponseDTO<List<UserDTO>>();

            try
            {
                serviceResponseDTO.Data = await _userBusiness.GetAll(userFilterDTO);
            }
            catch (Exception ex)
            {
                serviceResponseDTO.IsSucess = false;
                serviceResponseDTO.Message = ConstantMessages.FailureMessage(ex.GetBaseException().Message);
            }

            return serviceResponseDTO;
        }

        public async Task<ServiceResponseDTO<bool>> Update(UserDTO userDTO)
        {
            ServiceResponseDTO<bool> serviceResponseDTO = new ServiceResponseDTO<bool>();
            try
            {
                serviceResponseDTO.Data = await _userBusiness.Update(userDTO);
            }
            catch (Exception ex)
            {
                serviceResponseDTO.IsSucess = false;
                serviceResponseDTO.Message = ConstantMessages.FailureMessage(ex.GetBaseException().Message);
            }

            return serviceResponseDTO;
        }
    }
}