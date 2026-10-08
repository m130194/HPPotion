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

        //private ActualPotion _selectedPotion;

        private readonly APIService _apiService;
        private readonly Repository _repository;

        public ObservableCollection<ActualPotion> SavedPotionsToMake =>
            _repository.SavedPotionsToMake;
        public ObservableCollection<ActualPotion> PotionSearchResults { get; set; } = new();
        public Command ButtonSearchCommand { get; private set; }
        public Command TapAddPotionCommand { get; private set; }

        public Command<ActualPotion> SetSelectedPotionCommand { get; private set; }

        public PotionsViewModel(APIService apiService, Repository repository)
        {
            _apiService = apiService;
            _repository = repository;
            ButtonSearchCommand = new Command(async () => await SearchPotionsAsync());
            TapAddPotionCommand = new Command<ActualPotion>((selectedPotion) => AddPotion(selectedPotion));
            //SetSelectedPotionCommand = new Command<ActualPotion>((selectedPotion) => SetSelectedPotion(selectedPotion));
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

        //public void SetSelectedPotion(ActualPotion selectedPotion)
        //{
        //    _selectedPotion = selectedPotion;
        //}

        public void AddPotion(ActualPotion selectedPotion) 
        {
            if (selectedPotion != null)
            {
                //_repository.AddPotionToSavedPotionsToMake(_selectedPotion);
                SavedPotionsToMake.Add(selectedPotion);
            }
        }




        //Binding code ItemsSource="{Binding Source={x:Reference MainPage}, Path=BindingContext.PotionSearchResults}   
        //SelectionMode="Single" SelectedItem="{Binding _selectedPotion}"

    }
}
