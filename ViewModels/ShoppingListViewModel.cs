using HarryPotterPotions.Models;
using HarryPotterPotions.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HarryPotterPotions.ViewModels
{


    public class ShoppingListViewModel
    {
        private readonly IngredientRepository _ingredientRepository;

        public ObservableCollection<ActualPotion> SavedPotions =>
            _ingredientRepository.SavedPotions;

        public ShoppingListViewModel(IngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }
    }
}
