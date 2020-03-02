using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recipes.Models;

namespace Recipes.Repository.ReceipeSelectionRepository
{
    public interface IRecipeSelectionRepository
    {
        Task<(List<Recipe> Recipes, bool IsSuccess)> GetDinnerRecipes();
        Task<(List<Recipe> Recipes, bool IsSuccess)> GetDessertRecipes();
    }
}
