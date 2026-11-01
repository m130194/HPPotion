using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System.Collections.ObjectModel;
using HarryPotterPotions.ViewModels;

namespace HarryPotterPotions.Views
{
    public partial class MainPage : ContentPage
    {
        List<Potion> potions;

        public MainPage(PotionsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }

        private async void OnGoToShoppingListClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new ShoppingListPage());
            await Shell.Current.GoToAsync(nameof(ShoppingListPage));
            //Shell.Current.GoToAsync("ShoppingList");

        }
    }
}
