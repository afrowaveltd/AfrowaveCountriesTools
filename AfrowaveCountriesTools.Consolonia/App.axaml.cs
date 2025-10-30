using AfrowaveCountriesTools.Shared.Services;
using Microsoft.Extensions.DependencyInjection;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AfrowaveCountriesTools.Shared.ViewModels;

namespace AfrowaveCountriesTools.Consolonia;

/// <summary>
/// Represents the application entry point and core initialization logic for the Avalonia application.
/// </summary>
/// <remarks>This class is responsible for loading application resources and configuring the main window and its
/// data context during startup. It overrides framework initialization methods to set up dependency injection and
/// establish the main window for classic desktop-style lifetimes. Typically, you do not need to instantiate or modify
/// this class directly; it is used by the Avalonia framework to bootstrap the application.</remarks>
public partial class App : Application
{
   /// <summary>
   /// Initializes the control and loads its XAML content.
   /// </summary>
   /// <remarks>Call this method to ensure that the control's visual tree and resources are loaded from its
   /// associated XAML file. This method should typically be invoked during the control's construction or setup phase
   /// before accessing its visual elements.</remarks>
   public override void Initialize()
   {
      AvaloniaXamlLoader.Load(this);
   }

   /// <summary>
   /// Initializes the application framework and sets up the main window and its data context after all framework
   /// services have been configured.
   /// </summary>
   /// <remarks>This method is typically called by the application host during startup. It configures
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