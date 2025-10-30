using AfrowaveCountriesTools.Shared.Data;
using AfrowaveCountriesTools.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace AfrowaveCountriesTools.Shared;

/// <summary>
/// Provides extension methods for registering common application services with an <see cref="IServiceCollection"/>
/// instance.
/// </summary>
public static class ServiceCollectionExtensions
{
   /// <summary>
   /// Adds common application services, including the main window view model and the database context, to the specified
   /// service collection.
   /// </summary>
   /// <remarks>This method registers the main window view model with transient lifetime and configures the
   /// application database context to use SQLite. Call this method during application startup to ensure required
   /// services are available for dependency injection.</remarks>
   /// <param name="services">The service collection to which the common services will be registered. Cannot be null.</param>
   public static void AddCommonServices(this IServiceCollection services)
   {
      services.AddTransient<MainWindowViewModel>();
      services.AddDbContext<ApplicationDbContext>(options =>
      {
         options.UseSqlite("Data Source=countries_tools.db");
      });
   }
}