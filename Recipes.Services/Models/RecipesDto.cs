using System;
using System.Collections.Generic;
using Recipes.Models;
using Xamarin.Forms;

namespace Recipes.Services.Models
{
    public class RecipesDto : Status
    {
        public List<RecipeDto> recipes { get; set; }
        public OperationStatus operationStatus { get; set; }
    }

    public class RecipeDto
    {
        public string name { get; set; }
        public string ingredients { get; set; }
        public string directions { get; set; }
        public string author { get; set; }
        public string type { get; set; }
        public string category { get; set; }
        public string prepTime { get; set; }
        public string cookTime { get; set; }
        public string totalTime { get; set; }
        public string servings { get; set; }
        public int calories { get; set; }
        public ImageSource image { get; set; }
    }
}
