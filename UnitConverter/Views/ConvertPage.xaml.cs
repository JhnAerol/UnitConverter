using UnitConverter.ViewModels;

namespace UnitConverter.Views;

public partial class ConvertPage : ContentPage
{
	ConvertPageViewModel viewModel;

    public ConvertPage(ConvertPageViewModel _viewModel)
	{
		InitializeComponent();
		viewModel = _viewModel;	
		BindingContext = viewModel;
	}

    private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
		await DisplayAlert("Picker", viewModel.ToUnit, "OK");
    }
}