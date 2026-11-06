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

       private double _globalFontSize = 14;
        public double GlobalFontSize
        {
            get => _globalFontSize;
            set
            {
                if (_globalFontSize == value)
                    return;
                _globalFontSize = value;
                Preferences.Default.Set(
            "AppFontSize",
            value);
                OnPropertyChanged(nameof(GlobalFontSize));
                Application.Current!.Resources["GlobalFontSize"] = value;
            }
        }

        public AppViewModel()
        {
            GlobalFontSize =
                Preferences.Default.Get("GlobalFontSize", 14d);
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
