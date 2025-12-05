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

        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        if(Tounit.SelectedItem != null && Fromunit.SelectedItem != null)
        {
            viewModel.Result = viewModel.ConvertValue(viewModel.Input, viewModel.FromUnit, viewModel.ToUnit);
        }
    }

    private void InputEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (Tounit.SelectedItem != null && Fromunit.SelectedItem != null)
        {
            viewModel.Result = viewModel.ConvertValue(viewModel.Input, viewModel.FromUnit, viewModel.ToUnit);
        }
    }

    private void BackButton_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}