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
    public class PotionsViewModel

    {
        

        private readonly IngredientRepository _ingredientRepository;

        public ObservableCollection<ActualPotion> SavedPotions =>
            _ingredientRepository.SavedPotions;

        public PotionsViewModel(IngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }


        public void AddPotion(ActualPotion newPotion) {
            SavedPotions.Add(newPotion);
        }

        

            
        

    }
}
