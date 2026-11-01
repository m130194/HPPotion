using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HarryPotterPotions.Services
{
    public class PreferencesService
    {
        public event EventHandler<string> PreferenceChanged;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
