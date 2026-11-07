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

        

        private double _globalFontSize = Preferences.Default.Get("GlobalFontSize", 20);
        public double GlobalFontSize
        {
            get => _globalFontSize;
            set
            {

                _globalFontSize = value;

                Preferences.Default.Set(
                        "GlobalFontSize",
                        value);

                OnPropertyChanged(nameof(GlobalFontSize));

                Application.Current!.Resources["GlobalFontSize"] = value;
            }
        }

        //this is for testing purposes. why is this always false?
        bool hasValue = Preferences.Default.ContainsKey("GlobalFontSize");

        public AppViewModel()
        {

        }

        //bool hasValue = Preferences.Default.ContainsKey("GlobalFontSize");

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
