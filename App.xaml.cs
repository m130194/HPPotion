using HarryPotterPotions.Services;
using HarryPotterPotions.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using SQLite;

namespace HarryPotterPotions
{
    public partial class App : Application
    {

        //this is for testing purposes
        bool hasValue = Preferences.Default.ContainsKey("GlobalFontSize");

        public App()
        {
            InitializeComponent();
            double globalFontSize = Preferences.Default.Get("GlobalFontSize", 14);
            Application.Current!.Resources["GlobalFontSize"] = globalFontSize;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}