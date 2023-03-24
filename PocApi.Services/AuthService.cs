using PocApi.Business.Interfaces;
using PocApi.Data.UnityOfWork;
using PocApi.DTOs;
using PocApi.Services.Interfaces;
using PocApi.Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IUnityOfWork _unityOfWork;
        public AuthService(IUserBusiness userBusiness, IUnityOfWork unityOfWork)
        {
            _userBusiness = userBusiness;
            _unityOfWork = unityOfWork;
        }     


        public async Task<ServiceResponseDTO<string>> Login(UserLoginDTO userLoginDTO)
        {
            ServiceResponseDTO<string> serviceResponseDTO = new ServiceResponseDTO<string>();
            try
            {
                UserDTO _userDTO = await _userBusiness.GetByEmail(userLoginDTO.Email);

                if (_userDTO != null)
                {
                    serviceResponseDTO.Data = "Login efetuado";
                }
                else
                {
                    serviceResponseDTO.Data = "Usuário não encontrado";
                }

            }
            catch (Exception ex)
            {
                serviceResponseDTO.IsSucess = false;
                serviceResponseDTO.Message = ConstantMessages.FailureMessage(ex.GetBaseException().Message);
            }

            return serviceResponseDTO;
        }

        public Task<ServiceResponseDTO<UserDTO>> Register(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
