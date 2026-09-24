using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System.Collections.ObjectModel;
using HarryPotterPotions.ViewModels;

namespace HarryPotterPotions.Views
{
    public partial class MainPageView : ContentPage
    {
        List<ActualPotion> potions;

        //public ObservableCollection<Potion> savedPotions { get; }
        //    = new ObservableCollection<Potion>();


        public MainPageView(PotionsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            //SavedPotionsList.BindingContext = HarryPotterPotions.ViewModels.PotionsViewModel.SavedPotions;

        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            APIService service = new();
            potions = await service.GetPotionsAsync(NameSearch.Text);
            PotionsListView.ItemsSource = potions;
        }

        //public void AddPotion(Potion newPotion)
        //{
        //    savedPotions.Add(newPotion);
        //}

        private void OnAddPotionClicked(object sender, EventArgs e)
        {
            var viewModel = BindingContext as PotionsViewModel;
            ActualPotion? selected = PotionsListView.SelectedItem as ActualPotion;
            viewModel?.AddPotion(selected);
            //PotionsListView
        }

        private async void OnGoToShoppingListClicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new ShoppingListView());
            await Shell.Current.GoToAsync(nameof(IngredientInventoryView));
            //Shell.Current.GoToAsync("ShoppingList");

        }
    }
}
