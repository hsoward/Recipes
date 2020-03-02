using System;
using System.ComponentModel;

namespace Recipes.Helpers
{
    public enum RecipeType
    {
        [Description("Mexican")]
        MEXICAN,
        [Description("American")]
        AMERICAN,
        [Description("Italian")]
        ITALIAN
    }
}
