using UnitConverter.ViewModels;

namespace UnitConverter.Views;

public partial class ConvertPage : ContentPage
{
	public ConvertPage(ConvertPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}