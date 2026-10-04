using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System.Collections.ObjectModel;
using HarryPotterPotions.ViewModels;

namespace HarryPotterPotions.Views
{
    public partial class MainPageView : ContentPage
    {
        List<ActualPotion> potions;

        public MainPageView(PotionsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private async void OnGoToShoppingListClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new ShoppingListView());
            await Shell.Current.GoToAsync(nameof(ShoppingListView));
            //Shell.Current.GoToAsync("ShoppingList");

        }
    }
}
