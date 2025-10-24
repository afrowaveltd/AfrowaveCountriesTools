using AfrowaveCountriesTools.Consolonia.ViewModels;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;

namespace AfrowaveCountriesTools.Consolonia;

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