using System;
using System.ComponentModel;

namespace Recipes.Helpers
{
    public enum RecipeCategory
    {
        [Description("Dinner")]
        DINNER,
        [Description("Dessert")]
        DESSERT,
        [Description("Breakfast")]
        BREAKFAST
    }
}
