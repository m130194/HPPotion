using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace HarryPotterPotions.Services
{
    public class PreferencesService
    {
        public event EventHandler<string> PreferenceChanged;

        public void SetPreference(string key, int value)
        {
            Preferences.Default.Set(key, value);
            PreferenceChanged?.Invoke(this, key);
        }

        public int GetPreference(string key, int defaultValue)
        {
            return Preferences.Default.Get(key, defaultValue);
        }
    }
}
