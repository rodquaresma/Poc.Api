using Microsoft.EntityFrameworkCore;
using PocApi.Entities;


namespace PocApi.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }

        //protected override void OnModelCreating (ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppContext).Assembly);
        //}

        public List<User> Users { get; set; } = default!;
    }
}
