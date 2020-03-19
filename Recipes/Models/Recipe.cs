using System;
using MTI.XamEssentials.MxeMvvm;
using Xamarin.Forms;

namespace Recipes.Models
{
    public class Recipe : MxeObservableObject
    {
        public string Name { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }
        public string Author { get; set; }
        public string PrepTime { get; set; }
        public string CookTime { get; set; }
        public string TotalTime { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public string Servings { get; set; }
        public int Calories { get; set; }
        public ImageSource Image { get; set; }
    }
}
