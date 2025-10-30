using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace Afrowave.CountriesTools.ReactiveUi;

/// <summary>
/// Represents the user interface view for the first page in the application.
/// </summary>
/// <remarks>This control is typically used as the initial view in a multi-page application or navigation flow. It
/// inherits from <see cref="UserControl"/>, allowing it to be embedded within other controls or windows. To customize
/// the appearance or behavior, modify the associated XAML and code-behind files.</remarks>
public partial class FirstPageView : UserControl
{
   /// <summary>
   /// Initializes a new instance of the FirstPageView class and sets up the user interface components.
   /// </summary>
   /// <remarks>This constructor should be called when creating a FirstPageView to ensure that all UI elements are
   /// properly initialized. Typically used in XAML-based applications to instantiate the view.</remarks>
   public FirstPageView()
   {
      InitializeComponent();
   }
}