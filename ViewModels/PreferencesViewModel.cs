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
    }
}
