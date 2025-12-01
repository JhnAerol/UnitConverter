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
       
    }
}
