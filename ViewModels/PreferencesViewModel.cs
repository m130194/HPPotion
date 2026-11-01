using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Text;

namespace HarryPotterPotions.ViewModels
{
    public class PreferencesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private readonly PreferencesService _prefsService;

        public PreferencesViewModel(PreferencesService prefsService)
        {
            _prefsService = prefsService;
            // will add something here soon
        }

        // will add something more here soon
    }
}
