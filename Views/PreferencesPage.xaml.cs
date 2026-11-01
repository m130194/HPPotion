namespace HarryPotterPotions.Views;
using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using HarryPotterPotions.ViewModels;

public partial class PreferencesPage : ContentPage
{
	public PreferencesPage(PreferencesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}