using Afrowave.CountriesTools.ReactiveUi.ViewModels;
using AfrowaveCountriesTools.Shared.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Afrowave.CountriesTools.ReactiveUi;

public static class ServiceCollectionExtensions
{
	public static void AddCommonServices(this IServiceCollection services)
	{
		services.AddTransient<MainWindowViewModel>();
		services.AddDbContext<ApplicationDbContext>(options =>
		{
			options.UseSqlite("Data Source=countries_tools.db");
		});
	}
}