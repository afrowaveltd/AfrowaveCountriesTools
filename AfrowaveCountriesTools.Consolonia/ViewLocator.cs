using AfrowaveCountriesTools.Consolonia.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace AfrowaveCountriesTools.Consolonia;

public class ViewLocator : IDataTemplate
{
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

		Type? type = null;
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

	public bool Match(object? data)
	{
		return data is ViewModelBase;
	}
}