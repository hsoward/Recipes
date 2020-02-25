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

        private List<Recipe> allRecipes = new List<Recipe>();
        public List<Recipe> AllRecipes
        {
            get => allRecipes;
            set => SetProperty(ref allRecipes, value);
        }

        private List<Recipe> americanRecipes = new List<Recipe>();
        public List<Recipe> AmericanRecipes
        {
            get => americanRecipes;
            set => SetProperty(ref americanRecipes, value);
        }

        private List<Recipe> mexicanRecipes = new List<Recipe>();
        public List<Recipe> MexicanRecipes
        {
            get => mexicanRecipes;
            set => SetProperty(ref mexicanRecipes, value);
        }

        private List<Recipe> italianRecipes = new List<Recipe>();
        public List<Recipe> ItalianRecipes
        {
            get => italianRecipes;
            set => SetProperty(ref italianRecipes, value);
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
                    FilteredRecipes = new MxeObservableRangeCollection<Recipe>(AllRecipes.Where(o => o.Name.ToLower().Contains(searchString.ToLower())));
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
            await GetAllMexicanRecipesAsync();
            await GetAllAmericanRecipesAsync();
            await GetAllItalianRecipesAsync();
            await GetAllRecipesAsync();
        }
        #endregion

        private async Task GetAllRecipesAsync()
        {
            var response = await _recipeSelectionRepository.GetAllRecipes();

            if (response.IsSuccess)
            {
                AllRecipes = response.Recipes;
            }
            else
            {
                UserDialogs.Instance.Toast(DialogUtils.GetToastConfig(DialogType.ERROR, "Unable to retrieve all recipes at this time."));
            }
        }

        private async Task GetAllMexicanRecipesAsync()
        {
            var response = await _recipeSelectionRepository.GetAllMexicanRecipes();

            if (response.IsSuccess)
            {
                MexicanRecipes = response.Recipes;
            }
            else
            {
                UserDialogs.Instance.Toast(DialogUtils.GetToastConfig(DialogType.ERROR, "Unable to retrieve mexican recipes at this time."));
            }
        }

        private async Task GetAllAmericanRecipesAsync()
        {
            var response = await _recipeSelectionRepository.GetAllAmericanRecipes();

            if (response.IsSuccess)
            {
                AmericanRecipes = response.Recipes;
            }
            else
            {
                UserDialogs.Instance.Toast(DialogUtils.GetToastConfig(DialogType.ERROR, "Unable to retrieve american recipes at this time."));
            }
        }

        private async Task GetAllItalianRecipesAsync()
        {
            var response = await _recipeSelectionRepository.GetAllItalianRecipes();

            if (response.IsSuccess)
            {
                ItalianRecipes = response.Recipes;
            }
            else
            {
                UserDialogs.Instance.Toast(DialogUtils.GetToastConfig(DialogType.ERROR, "Unable to retrieve italian recipes at this time."));
            }
        }
    }
}
