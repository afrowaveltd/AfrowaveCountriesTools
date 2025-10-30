using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Interactivity;

namespace AfrowaveCountriesTools.Consolonia;

/// <summary>
/// Represents the main window of the application, providing the primary user interface and entry point for user
/// interaction.
/// </summary>
/// <remarks>This class is typically instantiated at application startup and serves as the root visual element. It
/// is responsible for initializing UI components and handling top-level window events. In most applications, only one
/// instance of MainWindow exists during the application's lifetime.</remarks>
public partial class MainWindow : Window
{
   /// <summary>
   /// Initializes a new instance of the MainWindow class.
   /// </summary>
   /// <remarks>This constructor sets up the main application window and loads its components. Typically called by
   /// the application framework when the window is created.</remarks>
   public MainWindow()
   {
      InitializeComponent();
   }

   private void OnExit(object sender, RoutedEventArgs e)
   {
      var lifetime = Application.Current!.ApplicationLifetime as IControlledApplicationLifetime;
      lifetime!.Shutdown();
   }
}