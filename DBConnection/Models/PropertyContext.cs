using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace DBConnection.Models
{
    public class PropertyContext : DbContext
    {
        private readonly IConfiguration _config;
        public DbSet<Mortgage> Mortgage { get; set; }
        public DbSet<Offers> Offers { get; set; }
        public DbSet<PropertyExpense> PropertyExpense { get; set; }
        public DbSet<CompanyExpense> CompanyExpense { get; set; }
        public DbSet<PropertyModel> PropertyModel { get; set; }
        public DbSet<PropertySaleData> PropertySaleData { get; set; }

        public PropertyContext (DbContextOptions<PropertyContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    @"Server=(localdb)\mssqllocaldb;Database=Property;Trusted_Connection=True;ConnectRetryCount=0");
            optionsBuilder.UseSqlServer(_config["PropertyDBConectionString"]);

        }
    }
}
