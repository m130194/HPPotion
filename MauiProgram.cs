using System;
using System.Threading.Tasks;
using HarryPotterPotions.Services;
using HarryPotterPotions.ViewModels;
using Microsoft.Extensions.Logging;

namespace HarryPotterPotions
{
    public static class MauiProgram
    {
        static MauiProgram()
        {
            // 1. Handle managed exceptions
            AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
            {
                var exception = args.ExceptionObject as Exception;
                System.Diagnostics.Debug.WriteLine($"GLOBAL MANAGED EXCEPTION: {exception?.Message}");
                System.Diagnostics.Debug.WriteLine(exception?.StackTrace);
            };

            // 2. Handle task/async exceptions
            TaskScheduler.UnobservedTaskException += (sender, args) =>
            {
                System.Diagnostics.Debug.WriteLine($"GLOBAL ASYNC EXCEPTION: {args.Exception.Message}");
                System.Diagnostics.Debug.WriteLine(args.Exception.StackTrace);
                args.SetObserved(); // Prevents the app from crashing if possible
            };
        }

        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton<IngredientRepository>();
            builder.Services.AddSingleton<SQLService>();
            builder.Services.AddTransient<PotionsViewModel>();
            builder.Services.AddTransient<ShoppingListViewModel>();
            builder.Services.AddTransient<IngredientInventoryViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
