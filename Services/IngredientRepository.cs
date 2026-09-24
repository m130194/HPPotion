using HarryPotterPotions.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace HarryPotterPotions.Services
{
    public class IngredientRepository
    {

        public ObservableCollection<ActualPotion> SavedPotions { get; } = new();

    }
}
