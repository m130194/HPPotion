using HarryPotterPotions.Views;

namespace HarryPotterPotions
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPageView), typeof(MainPageView));
            Routing.RegisterRoute(nameof(ShoppingListView), typeof(ShoppingListView));
            Routing.RegisterRoute(nameof(IngredientInventoryView), typeof(IngredientInventoryView));
        }
    }
}
