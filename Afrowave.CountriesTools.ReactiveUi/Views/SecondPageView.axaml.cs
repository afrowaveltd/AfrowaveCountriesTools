using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Afrowave.CountriesTools.ReactiveUi;

/// <summary>
/// Represents a user interface control for displaying the content of the second page within an application.
/// </summary>
/// <remarks>This control is typically used in scenarios where navigation between multiple pages is required, such
/// as in tabbed or multi-view applications. It inherits from <see cref="UserControl"/>, allowing it to be integrated
/// into Windows Presentation Foundation (WPF) layouts and to participate in data binding and event handling.</remarks>
public partial class SecondPageView : UserControl
{
   /// <summary>
   /// Initializes a new instance of the SecondPageView class.
   /// </summary>
   /// <remarks>This constructor sets up the user interface components for the SecondPageView. Call this
   /// constructor when creating a new SecondPageView to ensure all controls are properly initialized.</remarks>
   public SecondPageView()
   {
      InitializeComponent();
   }
}