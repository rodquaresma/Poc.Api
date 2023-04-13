using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PocApi.Business.Interfaces;
using PocApi.Data.UnityOfWork;
using PocApi.DTOs;
using PocApi.Services.Interfaces;
using PocApi.Shared.Messages;
using PocApi.Shared.PasswordUtility;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserBusiness _userBusiness;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public AuthService(IUserBusiness userBusiness, IUnityOfWork unityOfWork, IMapper mapper, IConfiguration configuration)
        {
            _userBusiness = userBusiness;
            _unityOfWork = unityOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }


        public async Task<ServiceResponseDTO<string>> Login(UserLoginDTO userLoginDTO)
        {
            ServiceResponseDTO<string> serviceResponseDTO = new ServiceResponseDTO<string>();
            try
            {
                UserDTO _userDTO = await _userBusiness.GetByEmail(userLoginDTO.Email);

                if (_userDTO == null || _userDTO.Id == 0)
                {
                    serviceResponseDTO.Data = ConstantMessages.UserNotFound(userLoginDTO.Email);

                    return serviceResponseDTO;
                }

                else if (!PasswordHashUtility.CheckHash(userLoginDTO.Password, _userDTO.PasswordHash, _userDTO.PasswordSalt))
                {
                    serviceResponseDTO.Data = ConstantMessages.WrongPassword;

                    return serviceResponseDTO;
                }

                string token = CreateToken(_userDTO);
                serviceResponseDTO.Data = token;
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

        private string CreateToken(UserDTO userDTO)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, userDTO.Id.ToString()),
                new Claim(ClaimTypes.Name, userDTO.Email)
            };

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = signingCredentials
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

            return jwtSecurityTokenHandler.WriteToken(securityToken);
        }
    }
}
