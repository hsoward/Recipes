using System;
using System.ComponentModel;

namespace Recipes.Helpers
{
    public enum RecipeType
    {
        [Description("mexican")]
        MEXICAN,
        [Description("american")]
        AMERICAN,
        [Description("italian")]
        ITALIAN
    }
}
