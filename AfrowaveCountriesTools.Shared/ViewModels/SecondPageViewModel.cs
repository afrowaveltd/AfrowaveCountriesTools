using ReactiveUI;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AfrowaveCountriesTools.Shared.ViewModels;

/// <summary>
///  This is our ViewModel for the second page
/// </summary>
public class SecondPageViewModel : PageViewModelBase
{
   /// <summary>
   /// Initializes a new instance of the SecondPageViewModel class and sets up property change monitoring for navigation
   /// eligibility.
   /// </summary>
   /// <remarks>This constructor subscribes to changes in the MailAddress and Password properties. When either
   /// property changes, the CanNavigateNext state is updated automatically. This ensures that navigation logic remains
   /// in sync with user input.</remarks>
   public SecondPageViewModel()
   {
      // Listen to changes of MailAddress and Password and update CanNavigateNext accordingly
      this.WhenAnyValue(x => x.MailAddress, x => x.Password)
          .Subscribe(_ => UpdateCanNavigateNext());
   }

   private string? _MailAddress;

   /// <summary>
   /// The E-Mail of the user. This field is required
   /// </summary>
   [Required]
   [EmailAddress]
   public string? MailAddress
   {
      get { return _MailAddress; }
      set { this.RaiseAndSetIfChanged(ref _MailAddress, value); }
   }

   private string? _Password;

   /// <summary>
   /// The password of the user. This field is required.
   /// </summary>
   [Required]
   public string? Password
   {
      get { return _Password; }
      set { this.RaiseAndSetIfChanged(ref _Password, value); }
   }

   private bool _CanNavigateNext;

   // For this page the user can only go to the next page if all fields are valid. So we need a private setter.
   /// <summary>
   /// Gets a value indicating whether navigation to the next page is allowed based on the validity of all fields.
   /// </summary>
   /// <remarks>Navigation to the next page is permitted only when all required fields on the current page are
   /// valid. This property is typically used to enable or disable navigation controls in user interfaces.</remarks>
   public override bool CanNavigateNext
   {
      get { return _CanNavigateNext; }
      protected set { this.RaiseAndSetIfChanged(ref _CanNavigateNext, value); }
   }

   /// <summary>
   /// Gets a value indicating whether navigation to the previous item is always allowed.
   /// </summary>
   /// <remarks>This property always returns <see langword="true"/>. Attempting to set this property will
   /// result in a <see cref="NotSupportedException"/>.</remarks>
   // We allow navigate back in any case
   public override bool CanNavigatePrevious
   {
      get => true;
      protected set => throw new NotSupportedException();
   }

   // Update CanNavigateNext. Allow next page if E-Mail and Password are valid
   private void UpdateCanNavigateNext()
   {
      CanNavigateNext =
             !string.IsNullOrEmpty(_MailAddress)
          && _MailAddress.Contains('@')
          && !string.IsNullOrEmpty(_Password);
   }
}