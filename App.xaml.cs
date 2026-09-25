using Microsoft.Extensions.DependencyInjection;
using HarryPotterPotions.Services;
using SQLite;

namespace HarryPotterPotions
{
    public partial class App : Application
    {
        


        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}