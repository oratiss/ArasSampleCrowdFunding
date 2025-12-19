using Aras.SampleCrowdFunding.Application.DataModels.WriteModels.Categories;
using Aras.SampleCrowdFunding.Repository.Mssql.Mappings;
using Atisaz.Core.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Aras.SampleCrowdFunding.Repository.Mssql.DataContexts
{
    public class CustomerClubDataContext : DbContext, IEfDataContext
    {
        public CustomerClubDataContext(DbContextOptions<CustomerClubDataContext> options) : base(options)
        {
        }


        public  DbSet<WritableCategory> Categories { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoryMapping());
        }

        public new object Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new object Entry(object entity)
        {
            return base.Entry(entity);
        }

        public override int SaveChanges()
        {
            var selectedEntityList = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);
            foreach (var entity in selectedEntityList)
            {
                var stringProperties = entity.Entity.GetType()
                    .GetProperties()
                    .Where(pi => pi.PropertyType == typeof(string) && pi.GetGetMethod() != null);
                foreach (var stringProperty in stringProperties)
                {
                    object? safeValue = stringProperty.GetValue(entity.Entity) != null ? stringProperty.GetValue(entity.Entity)?.ToString().PersianConvert() : null;
                    stringProperty.SetValue(entity.Entity, safeValue, null);
                }
            }
            return base.SaveChanges();
        }
    }

    public class CustomerClubContextFactory : IDesignTimeDbContextFactory<CustomerClubDataContext>
    {
        public CustomerClubDataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CustomerClubDataContext>();
            //optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CustomerClubWriteDb;user id=sa;password=P@ssw0rd@8144; Encrypt=False; Connection Timeout=120");
            //optionsBuilder.UseSqlServer("Data Source=192.168.5.44,1433;Initial Catalog=CustomerClubWriteDb;user id=sa;password=P@ssw0rd@8144; Encrypt=False; Connection Timeout=120");
            optionsBuilder.UseSqlServer("Data Source=212.33.198.153,1433;Initial Catalog=CustomerClubWriteDb;user id=AppLogin;password=TehranUsa202433; Encrypt=False; Connection Timeout=120");

            return new CustomerClubDataContext(optionsBuilder.Options);
        }
    }
}
