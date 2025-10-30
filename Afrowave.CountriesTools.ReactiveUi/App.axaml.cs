using AfrowaveCountriesTools.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AfrowaveCountriesTools.Shared.ViewModels;

namespace Afrowave.CountriesTools.ReactiveUi;

/// <summary>
/// Represents the main application class for the Avalonia UI application, responsible for initializing application
/// resources and configuring the main window and its data context.
/// </summary>
/// <remarks>This class overrides core initialization methods to set up the application's XAML resources and
/// establish the main window using dependency injection. The main window's view model is registered and resolved via
/// the application's host services. Typically, this class is the entry point for application startup and lifecycle
/// management in Avalonia desktop applications.</remarks>
public partial class App : Application
{
   /// <summary>
   /// Initializes the component and loads its XAML content.
   /// </summary>
   /// <remarks>Call this method to ensure that the component's visual tree and resources are loaded from the
   /// associated XAML file. This method should typically be invoked during the component's construction or setup phase
   /// before interacting with its UI elements.</remarks>
   public override void Initialize()
   {
      AvaloniaXamlLoader.Load(this);
   }

   /// <summary>
   /// Initializes the application framework and sets up the main window and its data context after all framework services
   /// have been configured.
   /// </summary>
   /// <remarks>This method is typically called by the framework during application startup. It configures
   /// dependency injection for the main window's view model and assigns the main window to the desktop application
   /// lifetime. Override this method to customize application initialization logic, but ensure to call the base
   /// implementation to complete framework setup.</remarks>
   public override void OnFrameworkInitializationCompleted()
   {
      var host = HostBuilderFactory.BuildHost(configureServices: (ctx, services) =>
      {
         services.AddTransient<MainWindowViewModel>();
      });

      var vm = host.Services.GetRequiredService<MainWindowViewModel>();

      if(ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
      {
         desktop.MainWindow = new Views.MainWindow
         {
            DataContext = vm,
         };
      }

      base.OnFrameworkInitializationCompleted();
   }
}