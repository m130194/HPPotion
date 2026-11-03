using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;
using HarryPotterPotions.Services;

namespace HarryPotterPotions.ViewModels
{
    public class PreferencesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

         //helper method fires the event called from property setters with caller member name attribute
         protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        private readonly PreferencesService _prefsService;

        public PreferencesViewModel(PreferencesService prefsService)
        {
            _prefsService = prefsService;
            _prefsService.PreferenceChanged += OnPreferenceChanged;
        }

        private void OnPreferenceChanged(object sender, string key)
        {
            if (key == "MyTargetKey")
            {
                // Refresh properties
            }
        }

        public int FontSize
        {
            //get => _prefsService.GetPreference("FontSize", 12);
            //set
            //{
            //    if (value != FontSize)
            //    {
            //        _prefsService.SetPreference("FontSize", value);
            //        OnPropertyChanged();
            //    }
            //}
            get => field;
            set
            {
                field = value;
                OnPropertyChanged();
            }
        } = 12; // Default font size

        public void ChangeFontSize(int newSize)
        {
            FontSize = newSize;
            _prefsService.SetPreference("FontSize", newSize);
        }
    }
}
