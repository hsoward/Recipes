using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Recipes.Models;

namespace Recipes.Repository.ReceipeSelectionRepository
{
    public interface IRecipeSelectionRepository
    {
        Task<(List<Recipe> Recipes, bool IsSuccess)> GetAllRecipes();
        Task<(List<Recipe> Recipes, bool IsSuccess)> GetAllMexicanRecipes();
        Task<(List<Recipe> Recipes, bool IsSuccess)> GetAllAmericanRecipes();
        Task<(List<Recipe> Recipes, bool IsSuccess)> GetAllItalianRecipes();
    }
}
