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
using MTI.XamEssentials.Helpers;
using Xamarin.Forms;
using System.Linq;
using Recipes.Pages.RecipeDetailsPage;

namespace Recipes.Pages.RecipeSelectionPage
{
    [Preserve(AllMembers = true)]
    public class RecipeSelectionPageModel : MxeBasePageModel
    {
        #region Fields
        private readonly IRecipeSelectionRepository _recipeSelectionRepository;

        private bool IsLocked;
        private Recipe recipeOption;
        public Recipe RecipeOption
        {
            get => recipeOption;
            set => SetProperty(ref recipeOption, value);
        }
        #endregion

        #region Constructor

        public RecipeSelectionPageModel(IRecipeSelectionRepository recipeSelectionRepository)
        {
            _recipeSelectionRepository = recipeSelectionRepository;
            Title = "Recipes";
        }

        #endregion

        #region Properties
        public string ClearIcon => MaterialDesignFont.Close;

        private string searchTerm;
        public string SearchTerm
        {
            get => searchTerm;
            set => SetProperty(ref searchTerm, value);
        }

        private MxeObservableRangeCollection<Recipe> filteredRecipes = new MxeObservableRangeCollection<Recipe>();
        public MxeObservableRangeCollection<Recipe> FilteredRecipes
        {
            get => filteredRecipes;
            set => SetProperty(ref filteredRecipes, value);
        }

        private List<Recipe> dinnerRecipes = new List<Recipe>();
        public List<Recipe> DinnerRecipes
        {
            get => dinnerRecipes;
            set => SetProperty(ref dinnerRecipes, value);
        }

        private List<Recipe> dessertRecipes = new List<Recipe>();
        public List<Recipe> DessertRecipes
        {
            get => dessertRecipes;
            set => SetProperty(ref dessertRecipes, value);
        }

        private Recipe selectedRecipe;
        public Recipe SelectedRecipe
        {
            get => selectedRecipe;
            set => SetProperty(ref selectedRecipe, value);
        }
        #endregion

        #region Commands

        public Command SearchCommand
        {
            get
            {
                return new Command<string>((searchString) =>
                {
                    //FilteredRecipes = new MxeObservableRangeCollection<Recipe>(AllRecipes.Where(o => o.Name.ToLower().Contains(searchString.ToLower())));
                });
            }
        }

        public Command RecipeSelected
        {
            get
            {
                return new Command(async (recipe) =>
                {
                    if (IsLocked)
                    {
                        return;
                    }

                    IsLocked = true;
                    await CoreMethods.PushPageModel<RecipeDetailsPageModel>(SelectedRecipe);
                    await Task.Delay(600).ContinueWith(t => IsLocked = false);
                });
            }
        }
        #endregion


        #region Overrides

        public override async void Init(object initData)
        {
            await GetDinnerRecipesAsync();
            await GetDessertRecipesAsync();
        }
        #endregion

        private async Task GetDinnerRecipesAsync()
        {
            var response = await _recipeSelectionRepository.GetDinnerRecipes();

            if (response.IsSuccess)
            {
                DinnerRecipes = response.Recipes;
            }
            else
            {
                UserDialogs.Instance.Toast(DialogUtils.GetToastConfig(DialogType.ERROR, "Unable to retrieve all recipes at this time."));
            }
        }

        private async Task GetDessertRecipesAsync()
        {
            var response = await _recipeSelectionRepository.GetDessertRecipes();

            if (response.IsSuccess)
            {
                DessertRecipes = response.Recipes;
            }
            else
            {
                UserDialogs.Instance.Toast(DialogUtils.GetToastConfig(DialogType.ERROR, "Unable to retrieve all recipes at this time."));
            }
        }
    }
}
