using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using Don.Sportsstore.Authorization.Roles;
using Don.Sportsstore.MultiTenancy;
using Don.Sportsstore.Products;
using Don.Sportsstore.Users;

namespace Don.Sportsstore.EntityFramework
{
    public class SportsstoreDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public DbSet<Product> Products { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SportsstoreDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SportsstoreDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SportsstoreDbContext since ABP automatically handles it.
         */
        public SportsstoreDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SportsstoreDbContext(DbConnection existingConnection)
         : base(existingConnection, false)
        {

        }

        public SportsstoreDbContext(DbConnection existingConnection, bool contextOwnsConnection)
         : base(existingConnection, contextOwnsConnection)
        {

        }
    }
}
