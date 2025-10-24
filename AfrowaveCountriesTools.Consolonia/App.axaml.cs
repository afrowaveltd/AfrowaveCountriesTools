using AfrowaveCountriesTools.Consolonia.ViewModels;
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
		if(ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktopLifetime)
		{
			desktopLifetime.MainWindow = new MainWindow()
			{
				DataContext = new MainWindowViewModel()
			};
		}

		base.OnFrameworkInitializationCompleted();
	}
}