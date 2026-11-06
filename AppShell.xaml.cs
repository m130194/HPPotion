using HarryPotterPotions.Views;

namespace HarryPotterPotions
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(ShoppingListPage), typeof(ShoppingListPage));
            Routing.RegisterRoute(nameof(IngredientInventoryPage), typeof(IngredientInventoryPage));
            Routing.RegisterRoute(nameof(PreferencesPage), typeof(PreferencesPage));
        }
    }
}
