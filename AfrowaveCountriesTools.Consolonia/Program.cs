using Avalonia;
using Avalonia.ReactiveUI;
using Consolonia;

namespace AfrowaveCountriesTools.Consolonia;

public static class Program
{
	private static void Main(string[] args)
	{
		BuildAvaloniaApp()
			 .StartWithConsoleLifetime(args);
	}

	public static AppBuilder BuildAvaloniaApp()
	{
		return AppBuilder.Configure<App>()
			 .UseReactiveUI()
			 .UseConsolonia()
			 .UseAutoDetectedConsole()
			 .LogToException();
	}
}