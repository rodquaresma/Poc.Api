using PocApi.Data.Interfaces;
using PocApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Insert(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
