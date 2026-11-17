using HarryPotterPotions.Services;
using HarryPotterPotions.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using SQLite;

namespace HarryPotterPotions
{
    public partial class App : Application
    {

        

        public App()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, args) => {
                System.Diagnostics.Debug.WriteLine($"Crash: {((Exception)args.ExceptionObject).Message}");
                System.Diagnostics.Debug.WriteLine($"Inner: {((Exception)args.ExceptionObject).InnerException}");
            };
            InitializeComponent();
            double globalFontSize = Preferences.Default.Get("GlobalFontSize", (double)14d);
            Application.Current!.Resources["GlobalFontSize"] = globalFontSize;
        }

        //this is for testing purposes
        bool hasValue = Preferences.Default.ContainsKey("GlobalFontSize");

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}