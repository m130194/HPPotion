using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace HarryPotterPotions.ViewModels
{
    public class AppViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        private double _globalFontSize = 14;
        public double GlobalFontSize
        {
            get => _globalFontSize;
            set
            {
                _globalFontSize = value;
                OnPropertyChanged(nameof(GlobalFontSize));
            }
        }

        public Command IncreaseFontCommand { get; private set; }
        public Command DecreaseFontCommand { get; private set; }
   
        public AppViewModel()
        {
            IncreaseFontCommand = new Command(() => GlobalFontSize += 2);
            DecreaseFontCommand = new Command(() => GlobalFontSize -= 2);
        }
    }
}
