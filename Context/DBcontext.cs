using Disaster_Guide.Models;
using Microsoft.EntityFrameworkCore;

namespace Disaster_Guide.Context
{
    public class DBcontext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=FURKAN; database=DisasterGuideDB; integrated security=true; TrustServerCertificate=true");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("server=YELIS\\SQLEXPRESS; database=DisasterGuideDB; integrated security=true; TrustServerCertificate=true");
        //}
        public DbSet<TBLuser> users { get; set; }
    }
}
