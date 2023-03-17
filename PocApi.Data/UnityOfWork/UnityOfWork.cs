using PocApi.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocApi.Data.UnityOfWork
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly AppDbContext _appDbContext;
        public UnityOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _appDbContext.Database.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.Database.CommitTransactionAsync();
        }

        public async Task RollbackAsync()
        {
            await _appDbContext.Database.RollbackTransactionAsync();
            
        }

        public async Task SaveChangesAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
