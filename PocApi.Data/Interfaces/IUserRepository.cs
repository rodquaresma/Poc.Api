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
    }
}
