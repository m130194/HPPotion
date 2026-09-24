using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using HarryPotterPotions.ViewModels;

namespace HarryPotterPotions.Views;

public partial class ShoppingListView : ContentPage
{
    
    public ShoppingListView(ShoppingListViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}