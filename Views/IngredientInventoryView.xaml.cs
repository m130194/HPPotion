namespace HarryPotterPotions.Views;
using HarryPotterPotions.Services;
using HarryPotterPotions.Models;
using HarryPotterPotions.ViewModels;

public partial class IngredientInventoryView : ContentPage
{

    public IngredientInventoryView(IngredientInventoryViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

}