using System;
using System.Collections.Generic;
using System.Text;

namespace AfrowaveCountriesTools.Shared.ViewModels;

/// <summary>
///  This is our ViewModel for the first page
/// </summary>
public class FirstPageViewModel : PageViewModelBase
{
   /// <summary>
   /// The Title of this page
   /// </summary>
   public static string Title => "Vítejte u našeho příkladu.";

   /// <summary>
   /// The content of this page
   /// </summary>
   public static string Message => "Stiskněte \"Další\" pro registraci.";

   // This is our first page, so we can navigate to the next page in any case
   /// <summary>
   /// Gets a value indicating whether navigation to the next page is possible.
   /// </summary>
   /// <remarks>This property always returns <see langword="true"/> for the first page, indicating that
   /// navigation forward is permitted in all cases. Attempting to set this property will result in a <see
   /// cref="NotSupportedException"/>.</remarks>
   public override bool CanNavigateNext
   {
      get => true;
      protected set => throw new NotSupportedException();
   }

   // You cannot go back from this page
   /// <summary>
   /// Gets a value indicating whether navigation to the previous page is allowed.
   /// </summary>
   /// <remarks>This property always returns <see langword="false"/>. Attempting to set this property will
   /// result in a <see cref="NotSupportedException"/>.</remarks>
   public override bool CanNavigatePrevious
   {
      get => false;
      protected set => throw new NotSupportedException();
   }
}