using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TKD.Infrastructure
{
  public  class AppDbContextDesignTime : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=TKD;Integrated Security=True");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
