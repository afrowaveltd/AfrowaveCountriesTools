using AfrowaveCountriesTools.Shared.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;

namespace AfrowaveCountriesTools.Shared;

/// <summary>
/// Provides a data template that locates and instantiates a corresponding view for a given view model instance using
/// naming conventions.
/// </summary>
/// <remarks>The ViewLocator attempts to resolve a view type based on the namespace and class name of the provided
/// view model object. It supports common conventions such as replacing 'ViewModels' with 'Views' and changing the
/// 'ViewModel' suffix to 'View'. If a matching view type cannot be found, a fallback text block is returned. This class
/// is typically used in MVVM architectures to automate view resolution for view models.</remarks>
public class ViewLocator : IDataTemplate
{
   /// <summary>
   /// Creates a view control corresponding to the provided view model instance using naming conventions.
   /// </summary>
   /// <remarks>This method attempts to locate a view type by transforming the view model's type name according to
   /// common conventions, such as replacing 'ViewModels' with 'Views' and 'ViewModel' with 'View'. The view is
   /// instantiated from the same assembly as the view model when possible. If no matching view type is found, a fallback
   /// TextBlock is returned.</remarks>
   /// <param name="data">The view model instance for which to create a corresponding view control. Can be null.</param>
   /// <returns>A control representing the view associated with the specified view model. If no matching view is found, returns a
   /// TextBlock indicating the missing view or, if the input is null, a TextBlock indicating that the data was empty.</returns>
   public Control Build(object? data)
   {
      if(data is null)
      {
         return new TextBlock { Text = "data byla prázdná" };
      }

      var vmType = data.GetType();
      var fullName = vmType.FullName!;

      // Try common conventions:
      //1) Namespace segment ViewModels -> Views, class suffix ViewModel -> View
      var candidate1 = fullName.Replace("ViewModels", "Views").Replace("ViewModel", "View");
      //2) Remove the ViewModels segment entirely, only change class suffix
      var candidate2 = fullName.Replace(".ViewModels.", ".").Replace("ViewModel", "View");

      Type? type;
      // Prefer resolving from the same assembly as the ViewModel to avoid needing assembly-qualified names
      type = vmType.Assembly.GetType(candidate1)
         ?? vmType.Assembly.GetType(candidate2)
         ?? Type.GetType(candidate1)
         ?? Type.GetType(candidate2);

      if(type != null)
      {
         return (Control)Activator.CreateInstance(type)!;
      }
      else
      {
         return new TextBlock { Text = "Nenalezeno: " + candidate1 + " | " + candidate2 };
      }
   }

   /// <summary>
   /// Determines whether the specified object is an instance of the ViewModelBase class.
   /// </summary>
   /// <param name="data">The object to evaluate for compatibility with ViewModelBase. Can be null.</param>
   /// <returns>true if data is a non-null instance of ViewModelBase; otherwise, false.</returns>
   public bool Match(object? data)
   {
      return data is ViewModelBase;
   }
}