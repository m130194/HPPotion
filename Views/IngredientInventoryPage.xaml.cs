namespace HarryPotterPotions.Views;
using HarryPotterPotions.Services;
using HarryPotterPotions.Models;
using HarryPotterPotions.ViewModels;

public partial class IngredientInventoryPage : ContentPage
{

    public IngredientInventoryPage(InventoryViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

}