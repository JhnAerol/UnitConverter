using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private string input;

        [ObservableProperty]
        private string result;

        [ObservableProperty]
        private string fromUnit;

        [ObservableProperty]
        private string toUnit;
    }
}
