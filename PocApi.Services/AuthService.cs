using AutoMapper;
using PocApi.Business.Interfaces;
using PocApi.Data.UnityOfWork;
using PocApi.DTOs;
using PocApi.Services.Interfaces;
using PocApi.Shared.Messages;
using PocApi.Shared.PasswordUtility;
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
        private readonly IMapper _mapper;
        public AuthService(IUserBusiness userBusiness, IUnityOfWork unityOfWork, IMapper mapper)
        {
            _userBusiness = userBusiness;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
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

        public async Task<ServiceResponseDTO<UserToInsertDTO>> Register(UserToInsertDTO userToInsertDTO)
        {
            ServiceResponseDTO<UserToInsertDTO> serviceResponseDTO = new ServiceResponseDTO<UserToInsertDTO>();

            try
            {
                UserDTO userOnDatabase = await _userBusiness.GetByEmail(userToInsertDTO.Email);

                if (userOnDatabase != null)
                {
                    serviceResponseDTO.IsSucess = false;
                    serviceResponseDTO.Message = ConstantMessages.UserNotFound(userToInsertDTO.Email);
                }

                UserDTO userDTO = _mapper.Map<UserDTO>(userToInsertDTO);
                PasswordHashUtility.CreateHash(userToInsertDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
                userDTO.PasswordHash = passwordHash;
                userDTO.PasswordSalt = passwordSalt;
                userDTO.Id = await _userBusiness.Insert(userDTO);
                await _unityOfWork.CommitAsync();
                serviceResponseDTO.Data = _mapper.Map<UserToInsertDTO>(userDTO);
                
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
