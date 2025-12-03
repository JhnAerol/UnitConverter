using UnitConverter.ViewModels;

namespace UnitConverter.Views;

public partial class MenuPage : ContentPage
{
    List<string> units { get; set; }

    public MenuPage()
	{
		InitializeComponent();
	}

    private void ImageButton_Clicked(object sender, EventArgs e)
    {
		if (sender is ImageButton button)
		{
			var vm = new ConvertPageViewModel();
			string name = button.ClassId;

			string CName = name.Split(' ')[0];
            vm.ConvertionType = CName;

            switch (CName)
			{
				case "Area":
                    units = new List<string> { "Square millimeter", "Square centimeter", "Square meter", "Hectare", "Square kilometer", "Square inch", "Square foot", "Square yard", "Acre", "Square mile" };

                    break;
                case "Digital":
                    units = new List<string> { "Bit", "Byte", "Kilobyte", "Megabyte", "Gigabyte", "Terabyte", "Petabyte", "Exabyte", "Zettabyte", "Yottabyte" };

                    break;
                case "Mass":
                    units = new List<string> { "Milligram", "Gram", "Kilogram", "Metric ton", "Ounce", "Pound", "Stone", "US ton", "Imperial ton" };

                    break;
                case "Length":
                    units = new List<string> { "Millimeter", "Centimeter", "Decimeter", "Meter", "Decameter", "Hectometer", "Kilometer", "Micrometer", "Nanometer", "Megameter", "Inch", "Foot", "Yard", "Mile", "Furlong", "Chain", "Nautical mile", "League", "Astronomical Unit", "Light-year", "Parsec", "Hand", "Rod", "Pole", "Perch", "Cubit", "Span" };

                    break;
                case "Volume":
                    units = new List<string> { "Milliliter", "Centiliter", "Deciliter", "Liter", "Decaliter", "Hectoliter", "Cubic meter", "Cubic centimeter", "Cubic inch", "Cubic foot", "Gallon", "Quart", "Pint", "Cup", "Fluid ounce" };

                    break;
                case "Temperature":
                    units = new List<string> { "Celsius", "Fahrenheit", "Kelvin", "Rankine" };

                    break;
                case "Time":
                    units = new List<string> { "Second", "Minute", "Hour", "Day", "Week", "Month", "Year", "Decade", "Century", "Millennium" };

                    break;
                case "Energy":
                    units = new List<string> { "Joule", "Kilojoule", "Calorie", "Kilocalorie", "Watt-hour", "Kilowatt-hour", "Electronvolt", "British thermal unit", "Foot-pound" };

                    break;
                case "Speed":
                    units = new List<string> { "Meters per second", "Kilometers per hour", "Miles per hour", "Knot", "Foot per second" };

                    break;
                default:
                    break;

            }

			foreach (var unit in units)
			{
				vm.Units.Add(unit);
			}

			vm.ConvertionName = name;

            var convertPage = new ConvertPage(vm);
			Navigation.PushAsync(convertPage);
		}
    }
}
