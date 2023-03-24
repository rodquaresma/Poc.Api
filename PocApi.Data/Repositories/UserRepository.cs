using Microsoft.EntityFrameworkCore;
using PocApi.Data.Context;
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
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User> GetById(int id)
        {
            User user = await _appDbContext.Set<User>().FirstOrDefaultAsync(user => user.Id == id);

            return user;
        }

        public async Task<User> GetByEmail(string email)
        {
            User user = await _appDbContext.Set<User>().FirstOrDefaultAsync(user => user.Email == email);

            return user;
        }

        public async Task<int> Insert(User user)
        {
            await _appDbContext.Set<User>().AddAsync(user);
            await _appDbContext.SaveChangesAsync();

            return user.Id;
        }

        public async Task<bool> Update(User user)
        {
            _appDbContext.Set<User>().Update(user);
            await _appDbContext.SaveChangesAsync();

            return true;
        }



    }
}
