using Microsoft.Extensions.DependencyInjection;
using HarryPotterPotions.Services;
using SQLite;

namespace HarryPotterPotions
{
    public partial class App : Application
    {
        //static is accessible from the class level without instantiating
        private static SQLService databaseService = default!;

        public static SQLService DatabaseService
        {
            get
            {
                if(databaseService == null)
                {
                    //create database with provided location AppData folder in Windows. in mobile apps, the folder is protected within the app itself
                    databaseService = new SQLService(
                        Path.Combine(Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData), "ingredients.db"
                        ));
                }
                return databaseService;
            }
            set { databaseService = value; }
        }


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