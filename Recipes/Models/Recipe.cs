using System;
using Xamarin.Forms;

namespace Recipes.Models
{
    public class Recipe
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public ImageSource Image { get; set; }
        public int Calories { get; set; }
        public string Type { get; set; }
    }
}
