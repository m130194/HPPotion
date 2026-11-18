using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using HarryPotterPotions.ViewModels;

namespace HarryPotterPotions.Views;

public partial class ShoppingListPage : ContentPage
{
    
    public ShoppingListPage(ShoppingViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}