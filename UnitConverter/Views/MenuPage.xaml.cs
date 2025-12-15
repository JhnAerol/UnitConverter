using Microsoft.Maui.Controls.Platform;
using UnitConverter.ViewModels;
using UnitsNet;
using UnitsNet.Units;

namespace UnitConverter.Views;

public partial class MenuPage : ContentPage
{

    bool isPointing = false;
    CancellationTokenSource spinToken;
    public MenuPage()
	{
		InitializeComponent();
        StartClockAnimation();
    }

    public List<string> GetUnits(string quantityName)
    {
        return quantityName switch
        {
            "Length" => Enum.GetNames(typeof(LengthUnit)).ToList(),
            "Mass" => Enum.GetNames(typeof(MassUnit)).ToList(),
            "Volume" => Enum.GetNames(typeof(VolumeUnit)).ToList(),
            "Temperature" => Enum.GetNames(typeof(TemperatureUnit)).ToList(),
            "Speed" => Enum.GetNames(typeof(SpeedUnit)).ToList(),
            "Area" => Enum.GetNames(typeof(AreaUnit)).ToList(),
            "Information" => Enum.GetNames(typeof(InformationUnit)).ToList(),
            "Duration" => Enum.GetNames(typeof(DurationUnit)).ToList(),
            "Energy" => Enum.GetNames(typeof(EnergyUnit)).ToList(),
            _ => new List<string>()
        };
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
		if (sender is ImageButton button)
		{
			var vm = new ConvertPageViewModel();
			string name = button.ClassId;

			string CName = name.Split(' ')[0];
            vm.ConvertionType = CName;

            var units = GetUnits(CName);

            foreach (var unit in units)
            {
                vm.Units.Add(unit);
            }

            vm.ConvertionName = name;

            ImageButton IB = sender as ImageButton;

            T(IB);

            var convertPage = new ConvertPage(vm);
            await Navigation.PushAsync(convertPage);
        }
    }

    private async void T(ImageButton IB)
    {
        isPointing = true;
        spinToken?.Cancel();
        this.AbortAnimation("ArrowSpin");

        double angle = CalculateAngleToButton(IB);

        await Arrow.RotateTo(angle, 600, Easing.CubicOut);

        await Task.Delay(2000);

        isPointing = false;
        StartClockAnimation();
    }

    [Obsolete]
	private void StartClockAnimation()
	{
	    if (isPointing) return;
	
	    spinToken = new CancellationTokenSource();
	    var token = spinToken.Token;
	
	    Device.StartTimer(TimeSpan.FromMilliseconds(16), () =>
	    { 
	        if (isPointing || spinToken.IsCancellationRequested) 
	            return false; 
	
	        Arrow.Rotation = (Arrow.Rotation + 3) % 360; 
	
	        return true; 
	    });
	}

    private double CalculateAngleToButton(ImageButton button)
    {
        if (button.Parent is VerticalStackLayout stack &&
            stack.Parent is Frame frame)
        {
            var hOptions = frame.HorizontalOptions;
            var vOptions = frame.VerticalOptions;

            if (hOptions.Alignment == LayoutAlignment.Center &&
                vOptions.Alignment == LayoutAlignment.Start)
                return 0;

            if (hOptions.Alignment == LayoutAlignment.End &&
                vOptions.Alignment == LayoutAlignment.Start)
                return 45; 

            if (hOptions.Alignment == LayoutAlignment.End &&
                vOptions.Alignment == LayoutAlignment.Center)
                return 90;

            if (hOptions.Alignment == LayoutAlignment.End &&
                vOptions.Alignment == LayoutAlignment.End)
                return 135;

            if (hOptions.Alignment == LayoutAlignment.Center &&
                vOptions.Alignment == LayoutAlignment.End)
                return 180;

            if (hOptions.Alignment == LayoutAlignment.Start &&
                vOptions.Alignment == LayoutAlignment.End)
                return 225;

            if (hOptions.Alignment == LayoutAlignment.Start &&
                vOptions.Alignment == LayoutAlignment.Center)
                return 270;

            if (hOptions.Alignment == LayoutAlignment.Start &&
                vOptions.Alignment == LayoutAlignment.Start)
                return 315;
        }

        return 0;
    }
}
