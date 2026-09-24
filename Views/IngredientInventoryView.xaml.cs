namespace HarryPotterPotions.Views;
using HarryPotterPotions.Services;
using HarryPotterPotions.Models;
using HarryPotterPotions.ViewModels;

public partial class IngredientInventoryView : ContentPage
{
    //static property referencing database
    //SQLService databaseService = App.DatabaseService;
    public IngredientInventoryView(IngredientInventoryViewModel vm)
	{
		InitializeComponent();
        BindingContext = vm;
    }

    //private async Task UpdateIngredients()
    //{
    //    ListViewIngredients.ItemsSource = null;
    //    ListViewIngredients.ItemsSource = await databaseService.BrowseIngredientsAsync();
    //}
    //private async Task ButtonSave_Clicked(object sender, EventArgs e)
    //{
    //    Ingredient newIngredient = new()
    //    {
    //        Name = EntryName.Text,
    //        Quantity = 1,
    //        Measurement = "item",

    //    };
    //    int result = await databaseService.AddIngredientAsync(newIngredient);
    //    if (result == 1)
    //    {
    //        await UpdateIngredients();
    //    }
    //}

    //private async Task ButtonRefresh_Clicked(object sender, EventArgs e)
    //{
    //    await UpdateIngredients();
    //}
}