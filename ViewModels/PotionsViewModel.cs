using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;


namespace HarryPotterPotions.ViewModels
{
    public class PotionsViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string searchParam)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(searchParam));
        }

        private string _searchParam;

        public string SearchParam
        {
            get => _searchParam;
            set

                {
                    _searchParam = value;
                    OnPropertyChanged(nameof(SearchParam));
                }
            
        }

        ActualPotion _selectedPotion;

        private readonly APIService _apiService;
        private readonly IngredientRepository _ingredientRepository;

        public ObservableCollection<ActualPotion> SavedPotionsToMake =>
            _ingredientRepository.SavedPotionsToMake;
        public ObservableCollection<ActualPotion> PotionSearchResults { get; set; } = new();
        public Command ButtonSearchCommand { get; private set; }
        public Command<ActualPotion> ButtonAddPotionCommand { get; private set; }

        public PotionsViewModel(APIService apiService, IngredientRepository ingredientRepository)
        {
            _apiService = apiService;
            _ingredientRepository = ingredientRepository;
            ButtonSearchCommand = new Command(async () => await SearchPotionsAsync());
            ButtonAddPotionCommand = new Command<ActualPotion>(AddPotion);
        }

        public async Task SearchPotionsAsync()
        {
            PotionSearchResults.Clear();
            var potions = await _apiService.GetPotionsAsync(SearchParam);
            foreach (var potion in potions)
            {
                PotionSearchResults.Add(potion);
            }
        }

        public void AddPotion(_selectedPotion) {
            SavedPotionsToMake.Add(_selectedPotion);
        }

        

            
        

    }
}
