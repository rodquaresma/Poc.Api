using PocApi.DTOs.Filters;
using PocApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Data.Interfaces
{
    public interface IUserRepository
    {
        Task<int> Insert(User user);
        Task<bool> Update(User user);
        Task<User> GetById(int id);
        Task<User> GetByEmail(string email);
        Task<List<User>> GetAll(UserFilterDTO userFilterDTO);
    }
}
