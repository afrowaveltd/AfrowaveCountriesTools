using Afrowave.CountriesTools.ReactiveUi.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using System;

namespace Afrowave.CountriesTools.ReactiveUi;

public class ViewLocator : IDataTemplate
{
	public Control Build(object? data)
	{
		if(data is null)
		{
			return new TextBlock { Text = "data byla prázdná" };
		}

		var name = data.GetType().FullName!.Replace("ViewModel", "View");
		var type = Type.GetType(name);

		if(type != null)
		{
			return (Control)Activator.CreateInstance(type)!;
		}
		else
		{
			return new TextBlock { Text = "Nenalezeno: " + name };
		}
	}

	public bool Match(object? data)
	{
		return data is ViewModelBase;
	}
}