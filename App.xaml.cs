using HarryPotterPotions.Services;
using HarryPotterPotions.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using SQLite;

namespace HarryPotterPotions
{
    public partial class App : Application
    {

        public static AppViewModel AppVM { get;  } = new();

        public App()
        {
            InitializeComponent();
            BindingContext = AppVM;
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new AppShell());
        }
    }
}