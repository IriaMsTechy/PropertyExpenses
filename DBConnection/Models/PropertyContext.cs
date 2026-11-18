using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace DBConnection.Models
{
    public class PropertyContext : DbContext
    {
        private readonly IConfiguration _config;
        public DbSet<Income> PropertyIncome { get; set; }
        public DbSet<Mortgage> Mortgage { get; set; }
        public DbSet<PropertyOffer> PropertyOffers { get; set; }
        public DbSet<PropertyExpense> PropertyExpenses { get; set; }
        public DbSet<CompanyExpense> CompanyExpenses { get; set; }
        public DbSet<PropertyModel> PropertyModels { get; set; }
        public DbSet<PropertySaleData> PropertySaleData { get; set; }
        public DbSet<PropertyValuation> PropertyValuations { get; set; }
        public DbSet<Mortgage> Mortgages { get; set; }

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PropertyOffer>()
                .HasOne(po => po.PropertyValuation)
                .WithMany()
                .HasForeignKey(po => po.PropertyValuationId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
    }
}
