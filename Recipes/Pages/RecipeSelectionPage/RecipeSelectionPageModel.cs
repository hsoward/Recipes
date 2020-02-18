using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MTI.XamEssentials.MxeMvvm;
using Recipes.Models;
using Recipes.Repository.ReceipeSelectionRepository;
using Xamarin.Forms.Internals;
using Recipes.Helpers;

namespace Recipes.Pages.RecipeSelectionPage
{
    [Preserve(AllMembers = true)]
    public class RecipeSelectionPageModel : MxeBasePageModel
    {
        #region Fields
        private readonly IRecipeSelectionRepository _recipeSelectionRepository;
        #endregion

        #region Constructor

        public RecipeSelectionPageModel(IRecipeSelectionRepository recipeSelectionRepository)
        {
            _recipeSelectionRepository = recipeSelectionRepository;
        }

        #endregion

        #region Properties
        private MxeObservableRangeCollection<Recipe> allRecipes = new MxeObservableRangeCollection<Recipe>();
        public MxeObservableRangeCollection<Recipe> AllRecipes
        {
            get => allRecipes;
            set => SetProperty(ref allRecipes, value);
        }

        private List<Recipe> recipeList = new List<Recipe>();
        public List<Recipe> RecipeList
        {
            get => recipeList;
            set => SetProperty(ref recipeList, value);
        }

        private Recipe selectedRecipe;
        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set => SetProperty(ref selectedRecipe, value);
        }
        #endregion

        #region Overrides

        public override async void Init(object initData)
        {
            await GetRecipesAsync();
        }
        #endregion

        private async Task GetRecipesAsync()
        {
            var response = await _recipeSelectionRepository.GetRecipesAsync();

            if (response.IsSuccess)
            {
                RecipeList = response.Recipes;
            }
            else
            {
                UserDialogs.Instance.Toast(DialogUtils.GetToastConfig(DialogType.ERROR, "Unable to retrieve locations at this time."));
            }
        }
    }
}
