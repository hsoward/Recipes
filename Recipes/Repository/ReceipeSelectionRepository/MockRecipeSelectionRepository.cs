using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MTI.Extensions;
using Recipes.Helpers;
using Recipes.Models;
using Recipes.Services.Models;
using Xamarin.Forms;

namespace Recipes.Repository.ReceipeSelectionRepository
{
    public class MockRecipeSelectionRepository : IRecipeSelectionRepository
    {
        public List<RecipeDto> mockOrders = new List<RecipeDto>();

        public Task<(List<Recipe> Recipes, bool IsSuccess)> GetAllAmericanRecipes()
        {
            if (mockOrders.Count == 0)
            {
                PopulateRecipes();
            }

            var americanRecipes = mockOrders.FindAll(x => x.type == RecipeType.AMERICAN.GetDescription());
            return Task.FromResult((Mapper.Map<List<RecipeDto>, List<Recipe>>(americanRecipes), true));
        }

        public Task<(List<Recipe> Recipes, bool IsSuccess)> GetAllItalianRecipes()
        {
            if (mockOrders.Count == 0)
            {
                PopulateRecipes();
            }

            var italianRecipes = mockOrders.FindAll(x => x.type == RecipeType.ITALIAN.GetDescription());
            return Task.FromResult((Mapper.Map<List<RecipeDto>, List<Recipe>>(italianRecipes), true));
        }

        public Task<(List<Recipe> Recipes, bool IsSuccess)> GetAllMexicanRecipes()
        {
            if (mockOrders.Count == 0)
            {
                PopulateRecipes();
            }
            
            var mexicanRecipes = mockOrders.FindAll(x => x.type == RecipeType.MEXICAN.GetDescription());
            return Task.FromResult((Mapper.Map<List<RecipeDto>, List<Recipe>>(mexicanRecipes), true));
        }

        public Task<(List<Recipe> Recipes, bool IsSuccess)> GetAllRecipes()
        {
            if (mockOrders.Count == 0)
            {
                PopulateRecipes();
            }

            var allRecipes = mockOrders;
            return Task.FromResult((Mapper.Map<List<RecipeDto>, List<Recipe>>(allRecipes), true));
        }

        public List<RecipeDto> PopulateRecipes()
        {
            mockOrders.Add(new RecipeDto
            {
                name = "Authentic Mexican Chili Rellenos",
                author = "Kentucky Guera",
                calories = 263,
                type = RecipeType.MEXICAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chiliRellenos.jpg")
                : ImageSource.FromFile("Images/chiliRellenos.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "Skinny Mexican Chicken Skillet",
                author = "Averie Sunshine",
                calories = 559,
                type = RecipeType.MEXICAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/skinnyMexicanChicken.jpg")
                : ImageSource.FromFile("Images/skinnyMexicanChicken.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "Chicken Fajitas",
                author = "Isabel Eats",
                calories = 263,
                type = RecipeType.MEXICAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chickenFajitas.jpg")
                : ImageSource.FromFile("Images/chickenFajitas.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "Healthy Mexican Casserole",
                author = "Kathi & Rachel",
                calories = 267,
                type = RecipeType.MEXICAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/mexicanCasserole.jpg")
                : ImageSource.FromFile("Images/mexicanCasserole.jpg")
            });

            mockOrders.Add(new RecipeDto
            {
                name = "Italian Skillet Chicken with Tomatoes and Mushrooms",
                author = "Suzy",
                calories = 218,
                type = RecipeType.ITALIAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/italianSkillet.jpg")
                : ImageSource.FromFile("Images/italianSkillet.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "Stuffed Shells With Ricotta and Spinach Recipe",
                author = "Daniel Gritzer",
                calories = 450,
                type = RecipeType.ITALIAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/stuffedShells.jpg")
                : ImageSource.FromFile("Images/stuffedShells.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "Chicken Marsala",
                author = "Sabrina Snyder",
                calories = 460,
                type = RecipeType.ITALIAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chickenMarsala.jpg")
                : ImageSource.FromFile("Images/chickenMarsala.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "Chop Suey ",
                author = "Kathleen",
                calories = 646,
                type = RecipeType.AMERICAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chopSuey.jpg")
                : ImageSource.FromFile("Images/chopSuey.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "All American Chili",
                author = "McCormick",
                calories = 310,
                type = RecipeType.AMERICAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chili.jpg")
                : ImageSource.FromFile("Images/chili.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "Crock pot American Goulash",
                author = "Eating on a Dime",
                calories = 718,
                type = RecipeType.AMERICAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/goulash.jpg")
                : ImageSource.FromFile("Images/goulash.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "All-American Potato Salad",
                author = "Jessica Gavin",
                calories = 200,
                type = RecipeType.AMERICAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/potatoSalad.jpg")
                : ImageSource.FromFile("Images/potatoSalad.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "Buffalo Chicken",
                author = "Emma Freud",
                calories = 520,
                type = RecipeType.AMERICAN.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/buffaloWings.jpg")
                : ImageSource.FromFile("Images/buffaloWings.jpg")
            });

            return mockOrders;
        }
    }
}
