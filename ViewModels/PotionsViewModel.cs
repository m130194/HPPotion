using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;



namespace HarryPotterPotions.ViewModels
{
    public class PotionsViewModel : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler? PropertyChanged;
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

        //private Potion _selectedPotion;

        private readonly APIService _apiService;
        private readonly Repository _repository;

        public ObservableCollection<Potion> SavedPotionsToMake =>
            _repository.SavedPotionsToMake;
        public ObservableCollection<Potion> PotionSearchResults { get; set; } = new();
        public Command ButtonSearchCommand { get; private set; }
        public Command TapAddPotionCommand { get; private set; }
        public Command DeletePotionCommand { get; private set; }

        public Command<Potion> SetSelectedPotionCommand { get; private set; }

        public PotionsViewModel(APIService apiService, Repository repository)
        {
            _apiService = apiService;
            _repository = repository;
            ButtonSearchCommand = new Command(async () => await SearchPotionsAsync());
            TapAddPotionCommand = new Command<Potion>((selectedPotion) => AddPotion(selectedPotion));
            DeletePotionCommand = new Command<Potion>((selectedPotion) => DeletePotion(selectedPotion));
            //SetSelectedPotionCommand = new Command<Potion>((selectedPotion) => SetSelectedPotion(selectedPotion));

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

        //public void SetSelectedPotion(Potion selectedPotion)
        //{
        //    _selectedPotion = selectedPotion;
        //}

        public void AddPotion(Potion selectedPotion) 
        {
            if (selectedPotion != null)
            {
                //_repository.AddPotionToSavedPotionsToMake(_selectedPotion);
                SavedPotionsToMake.Add(selectedPotion);
            }
        }

        public void DeletePotion(Potion selectedPotion)
        {
            if (selectedPotion != null)
            {
                SavedPotionsToMake.Remove(selectedPotion);
            }
        }


        //Binding code ItemsSource="{Binding Source={x:Reference MainPage}, Path=BindingContext.PotionSearchResults}   
        //SelectionMode="Single" SelectedItem="{Binding _selectedPotion}"

    }
}
