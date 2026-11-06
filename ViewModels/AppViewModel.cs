using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace HarryPotterPotions.ViewModels
{
    public class AppViewModel : INotifyPropertyChanged
    {

        private double _globalFontSize;
        public double GlobalFontSize
        {
            get => _globalFontSize;
            set
            {
                //if (_globalFontSize == value)
                //    return;
                Application.Current!.Resources["GlobalFontSize"] = value;
                _globalFontSize = value;
                
                OnPropertyChanged(nameof(GlobalFontSize));
                
                Preferences.Default.Set(
            "GlobalFontSize",
            value);
            }
        }

        public AppViewModel()
        {
            //GlobalFontSize =
            //    Preferences.Default.Get("GlobalFontSize", 20);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(
            [CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(
                this,
                new PropertyChangedEventArgs(propertyName));
        }
    }
}
