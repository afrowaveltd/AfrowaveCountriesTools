using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AfrowaveCountriesTools.Shared.Data
{
   /// <summary>
   /// Provides a factory for creating instances of <see cref="ApplicationDbContext"/> at design time, typically for use
   /// with Entity Framework Core tooling.
   /// </summary>
   /// <remarks>This class implements <see cref="IDesignTimeDbContextFactory{TContext}"/> to enable design-time
   /// services such as migrations and scaffolding. The <see cref="CreateDbContext"/> method reads configuration from the
   /// application's startup directory and constructs a <see cref="ApplicationDbContext"/> using the configured connection
   /// string. If no connection string is found, a default SQLite database is used. This factory is not intended for use
   /// at runtime within the application.</remarks>
   public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
   {
      /// <summary>
      /// Creates a new instance of ApplicationDbContext configured using the application's settings.
      /// </summary>
      /// <remarks>The method reads configuration from the current directory, including environment variables and
      /// the 'appsettings.json' file if present. If no connection string named 'Default' is found, a local SQLite database
      /// is used by default.</remarks>
      /// <param name="args">An array of command-line arguments. This parameter is not used in the context creation process.</param>
      /// <returns>A new ApplicationDbContext instance configured with the connection string specified in the application's
      /// configuration or a default SQLite database if none is provided.</returns>
      public ApplicationDbContext CreateDbContext(string[] args)
      {
         // Read configuration from the startup project's directory
         var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

         var cs = config.GetConnectionString("Default") ?? "Data Source=./data/app.db";

         var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
         optionsBuilder.UseSqlite(cs);

         return new ApplicationDbContext(optionsBuilder.Options);
      }
   }
}