using System.Data.Entity;
using Company.DomainModels;

namespace Company.DataLayer
{

    // This class represents the Entity Framework DbContext for the Company database.
    // It includes DbSets for each of the domain models: Brand, Category, and Product.
    public class CompanyDbContext : DbContext
    {
        // The base constructor is called with the name of the connection string ("MyConnectionString").
        // This connection string should be defined in the application's configuration file (e.g., web.config or app.config).
        public CompanyDbContext() : base("MyConnectionString")
        {
            // The line below sets the database initializer. 
            // By default, it's commented out. If uncommented, it will enable automatic migrations 
            // and update the database schema to the latest version based on the Configuration class in the Migrations folder.
            // This is useful during development to automatically apply any pending migrations when the application starts.


            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyDbContext, Configuration>());
        }

        // DbSets represent collections of the specified entities in the context.
        // These properties correspond to tables in the database.

        // Represents the Brands table in the database.
        public DbSet<Brand> Brands { get; set; }
        // Represents the Categories table in the database.
        public DbSet<Category> Categories { get; set; }
        // Represents the Products table in the database.
        public DbSet<Product> Products { get; set; }
    }
}


