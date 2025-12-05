using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitsNet;
using UnitsNet.Units;

namespace UnitConverter.ViewModels
{
    public partial class ConvertPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<string> units = new();

        [ObservableProperty]
        private string convertionName;

        [ObservableProperty]
        private string convertionType;

        [ObservableProperty]
        private double input = 0;

        [ObservableProperty]
        private double result;

        [ObservableProperty]
        private string fromUnit;

        [ObservableProperty]
        private string toUnit;

        public double ConvertValue(double value, string fromUnitName, string toUnitName)
        {
            IQuantity quantity = Quantity.From(value, ConvertionType, fromUnitName);
            IQuantity converted = quantity.ToUnit(Quantity
                                .ByName[ConvertionType]
                                .UnitInfos
                                .First(u => u.Name == toUnitName)
                                .Value);

            return (double)converted.Value;
        }
    }
}
