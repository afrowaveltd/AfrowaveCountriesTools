using System;
using System.Collections.Generic;
using System.Text;

namespace AfrowaveCountriesTools.Consolonia.ViewModels;

/// <summary>
///  This is our ViewModel for the first page
/// </summary>
public class ThirdPageViewModel : PageViewModelBase
{
	// The message to display
	public string Message => "Hotovo";

	// This is the last page, so we cannot navigate next in our sample.
	public override bool CanNavigateNext
	{
		get => false;
		protected set => throw new NotSupportedException();
	}

	// We navigate back form this page in any case
	public override bool CanNavigatePrevious
	{
		get => true;
		protected set => throw new NotSupportedException();
	}
}