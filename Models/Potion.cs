
//using Android.Net.Wifi;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace HarryPotterPotions.Models
{
    public class ActualPotion : INotifyPropertyChanged
    {
        public string Id { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;
        public string Ingredients { get; set; } = String.Empty;

        public event PropertyChangedEventHandler? PropertyChanged;

        public static implicit operator ActualPotion(Potion fromTheInternet)
        {
            return new ActualPotion()
            {
                Name = fromTheInternet.attributes.name,
                Ingredients = fromTheInternet.attributes.ingredients,
                Id = fromTheInternet.id
            };
        }

    }


    public class Potion
    {
        public string id { get; set; }
        public string type { get; set; }
        public PotionAttributes attributes { get; set; }
        public Links links { get; set; }
    }

    public class PotionAttributes
    {
        public string slug { get; set; }
        public string characteristics { get; set; }
        public string difficulty { get; set; }
        public string effect { get; set; }
        public string image { get; set; }
        public object inventors { get; set; }
        public string ingredients { get; set; }
        public object manufacturers { get; set; }
        public string name { get; set; }
        public object side_effects { get; set; }
        public object time { get; set; }
        public string wiki { get; set; }

    }

    public class Links
    {
        public string self { get; set; }
    }

    

    }
