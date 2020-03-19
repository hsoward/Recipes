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

        private List<Recipe> recipes = new List<Recipe>();
        public List<Recipe> Recipes
        {
            get => recipes;
            set => SetProperty(ref recipes, value);
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
                    var foundRecipes = Recipes.Where(o => o.Name.ToLower().Contains(searchString.ToLower()));
                    if (foundRecipes.Any())
                    {
                        Recipes = new List<Recipe>(foundRecipes);
                    }
                    else
                    {
                        UserDialogs.Instance.Toast(DialogUtils.GetToastConfig(DialogType.ERROR, $"No Recipe's found for {searchString}"));
                    }
                });
            }
        }

        public Command ClearCommand
        {
            get
            {
                return new Command<string>(async (searchString) =>
                {
                    SearchTerm = "";
                    await GetAllRecipesAsync();
                });
            }
        }

        public Command RecipeSelected
        {
            get
            {
                return new Command(async () =>
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
            await GetAllRecipesAsync();
        }
        #endregion

        private async Task GetAllRecipesAsync()
        {
            var response = await _recipeSelectionRepository.GetAllRecipes();

            if (response.IsSuccess)
            {
                Recipes = response.Recipes;
            }
            else
            {
                UserDialogs.Instance.Toast(DialogUtils.GetToastConfig(DialogType.ERROR, "Unable to retrieve all recipes at this time."));
            }
        }
    }
}
