using AfrowaveCountriesTools.Consolonia.ViewModels;
using AfrowaveCountriesTools.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace AfrowaveCountriesTools.Consolonia;

public partial class App : Application
{
	public override void Initialize()
	{
		AvaloniaXamlLoader.Load(this);
	}

	public override void OnFrameworkInitializationCompleted()
	{
		var host = HostBuilderFactory.BuildHost(configureServices: (ctx, services) =>
		{
			services.AddTransient<MainWindowViewModel>();
		});

		var vm = host.Services.GetRequiredService<MainWindowViewModel>();

		if(ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
		{
			desktopLifetime.MainWindow = new MainWindow()
			{
				DataContext = vm
			};
		}

		base.OnFrameworkInitializationCompleted();
	}
}