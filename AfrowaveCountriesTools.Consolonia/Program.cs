using Avalonia;
using Avalonia.ReactiveUI;
using Consolonia;

namespace AfrowaveCountriesTools.Consolonia;

/// <summary>
/// Provides the entry point and configuration methods for the Avalonia-based console application.
/// </summary>
/// <remarks>This class is responsible for initializing and starting the application using Avalonia, ReactiveUI,
/// and Consonolia frameworks. It configures the application to run with a console lifetime, enabling console-based
/// interaction. The class is static and cannot be instantiated.</remarks>
public static class Program
{
   private static void Main(string[] args)
   {
      BuildAvaloniaApp()
          .StartWithConsoleLifetime(args);
   }

   /// <summary>
   /// Configures and initializes an Avalonia application with ReactiveUI, Consolonia, and automatic console detection.
   /// </summary>
   /// <remarks>This method sets up the application to use ReactiveUI for MVVM support, Consolonia for
   /// console-based UI, and automatically detects the appropriate console environment. Logging is configured to capture
   /// exceptions. Call this method before starting the application to ensure all required frameworks are
   /// initialized.</remarks>
   /// <returns>An <see cref="AppBuilder"/> instance configured for the application. The returned builder can be used to start the
   /// application.</returns>
   public static AppBuilder BuildAvaloniaApp()
   {
      return AppBuilder.Configure<App>()
          .UseReactiveUI()
          .UseConsolonia()
          .UseAutoDetectedConsole()
          .LogToException();
   }
}