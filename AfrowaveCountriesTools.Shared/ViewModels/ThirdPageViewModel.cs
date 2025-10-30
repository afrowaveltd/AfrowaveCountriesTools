using System;
using System.Collections.Generic;
using System.Text;

namespace AfrowaveCountriesTools.Shared.ViewModels;

/// <summary>
///  This is our ViewModel for the first page
/// </summary>
public class ThirdPageViewModel : PageViewModelBase
{
   // The message to display
   /// <summary>
   /// Gets the message to display.
   /// </summary>
   public static string Message => "Hotovo";

   // This is the last page, so we cannot navigate next in our sample.
   /// <summary>
   /// Gets a value indicating whether navigation to the next item is possible. Always returns <see langword="false"/>
   /// for the last item.
   /// </summary>
   public override bool CanNavigateNext
   {
      get => false;
      protected set => throw new NotSupportedException();
   }

   // We navigate back form this page in any case
   /// <summary>
   /// Gets a value indicating whether navigation to the previous page is always allowed.
   /// </summary>
   /// <remarks>This property always returns <see langword="true"/>. Attempting to set this property will
   /// result in a <see cref="NotSupportedException"/>.</remarks>
   public override bool CanNavigatePrevious
   {
      get => true;
      protected set => throw new NotSupportedException();
   }
}