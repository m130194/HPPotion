namespace HarryPotterPotions.Views;
using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using HarryPotterPotions.ViewModels;

public partial class PreferencesPage : ContentPage
{
	public PreferencesPage(AppViewModel appVM)
	{
		InitializeComponent();
		BindingContext = appVM;
	}
}