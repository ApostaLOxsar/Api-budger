using System.Reflection;
using Api_budger.Models.budgers;
using Api_budger.Models.budgers.budgers;
using Api_budger.Models.clients;
using Api_budger.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Api_budger
{
    public class ApplicationContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DbSet<Budger> Budgers { get; set; }
        public DbSet<BudgerCategory> BudgerCategories { get; set;}
        public DbSet<BudgerCategoryHasFamily> BudgerCategoryHasFamilies { get; set; }
        public DbSet<DefaultBudgerCategory> DefaultBudgerCategories { get; set; }
        public DbSet<DefaultIncomeCategory> DefaultIncomeCategories { get; set;}
        public DbSet<Incom> Incoms { get; set; }
        public DbSet<IncomeCategory> IncomeCategories { get; set; }
        public DbSet<IncomeCategoryHasFamily> IncomeCategoriesHasFamilies { get;set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseNpgsql(connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BudgerCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BudgerCategoryHasFamilyConfiguration());
            modelBuilder.ApplyConfiguration(new BudgerConfiguration());
            modelBuilder.ApplyConfiguration(new DefaultBudgerCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new DefaultIncomeCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new FamilyConfiguration());
            modelBuilder.ApplyConfiguration(new IncomConfiguration());
            modelBuilder.ApplyConfiguration(new IncomeCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new IncomeCategoryHasFamilyConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());

            try
            {
                modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка конфигурации модели: " + ex.Message);
            }
        }
    }
}
