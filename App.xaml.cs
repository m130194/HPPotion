using HarryPotterPotions.Services;
using HarryPotterPotions.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using SQLite;

namespace HarryPotterPotions
{
    public partial class App : Application
    {

        public App(AppViewModel appVM)
        {
            InitializeComponent();
            Resources.Add("AppViewModel", appVM);
            MainPage = new AppShell();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}