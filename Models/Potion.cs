
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
        public string ID { get; set; }
        public string Name { get; set; }
        public string Ingredients { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public static implicit operator ActualPotion(Potion fromTheInternet)
        {
            return new ActualPotion()
            {
                Name = fromTheInternet.attributes.name,
                Ingredients = fromTheInternet.attributes.ingredients,
                ID = fromTheInternet.id
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

        public override string ToString()
        {
            return $"Potion: {name}";
        }
    }

    public class Links
    {
        public string self { get; set; }
    }

    

    }
