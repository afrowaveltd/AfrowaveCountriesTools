using ReactiveUI;

namespace AfrowaveCountriesTools.Shared.ViewModels;

/// <summary>
/// Serves as a base class for view models that support property change notification using reactive programming
/// patterns.
/// </summary>
/// <remarks>Inherit from this class to implement view models that notify observers of property changes, typically
/// for use in MVVM architectures. This class leverages the functionality of ReactiveObject to provide efficient and
/// composable property change notifications.</remarks>
public class ViewModelBase : ReactiveObject
{
}