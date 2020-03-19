using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MTI.XamEssentials.MxeMvvm;
using Recipes.Helpers;
using Recipes.Models;
using Recipes.Repository.ReceipeSelectionRepository;
using Xamarin.Forms;

namespace Recipes.Pages.RecipeDetailsPage
{
    public class RecipeDetailsPageModel : MxeBasePageModel
    {
        #region Fields
        private readonly IRecipeSelectionRepository _recipeSelectionRepository;

        private bool IsLocked;
        #endregion

        #region Constructor
        public RecipeDetailsPageModel(IRecipeSelectionRepository recipeSelectionRepository)
        {
            _recipeSelectionRepository = recipeSelectionRepository;
            Title = "Recipes";
        }
        #endregion

        private Recipe selectedRecipe;
        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set => SetProperty(ref selectedRecipe, value);
        }

        private List<Recipe> recipeDetails = new List<Recipe>();
        public List<Recipe> RecipeDetails
        {
            get => recipeDetails;
            set => SetProperty(ref recipeDetails, value);
        }

        #region Overrides

        public override async void Init(object initData)
        {
            if (initData != null)
            {
                SelectedRecipe = (Recipe)initData;

                await GetRecipeDetailsAsync(SelectedRecipe.Name);
                Title = SelectedRecipe.Name;
            }
        }
        #endregion

        private async Task GetRecipeDetailsAsync(string recipe)
        {
            var response = await _recipeSelectionRepository.GetRecipeDetails(recipe);

            if (response.IsSuccess)
            {
                RecipeDetails = response.Recipes;
            }
            else
            {
                UserDialogs.Instance.Toast(DialogUtils.GetToastConfig(DialogType.ERROR, "Unable to retrieve recipe details at this time."));
            }
        }
    }
}
