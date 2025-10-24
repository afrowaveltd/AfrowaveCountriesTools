﻿using Afrowave.CountriesTools.ReactiveUi.ViewModels;
using Afrowave.CountriesTools.ReactiveUi.Views;

using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace Afrowave.CountriesTools.ReactiveUi;

public partial class App : Application
{
	public override void Initialize()
	{
		AvaloniaXamlLoader.Load(this);
	}

	public override void OnFrameworkInitializationCompleted()
	{
		var collection = new ServiceCollection();
		collection.AddCommonServices();

		var services = collection.BuildServiceProvider();
		var vm = services.GetRequiredService<MainWindowViewModel>();

		if(ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
		{
			desktop.MainWindow = new MainWindow
			{
				DataContext = vm
			};
		}

		base.OnFrameworkInitializationCompleted();
	}
}