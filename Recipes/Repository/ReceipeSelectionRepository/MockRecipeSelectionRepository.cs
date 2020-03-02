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

        public Task<(List<Recipe> Recipes, bool IsSuccess)> GetDessertRecipes()
        {
            if (mockOrders.Count == 0)
            {
                PopulateRecipes();
            }

            var dessertRecipes = mockOrders.FindAll(x => x.category == RecipeCategory.DESSERT.GetDescription());
            return Task.FromResult((Mapper.Map<List<RecipeDto>, List<Recipe>>(dessertRecipes), true));
        }

        public Task<(List<Recipe> Recipes, bool IsSuccess)> GetDinnerRecipes()
        {
            if (mockOrders.Count == 0)
            {
                PopulateRecipes();
            }

            var dinnerRecipes = mockOrders.FindAll(x => x.category == RecipeCategory.DINNER.GetDescription());
            return Task.FromResult((Mapper.Map<List<RecipeDto>, List<Recipe>>(dinnerRecipes), true));
        }

        public List<RecipeDto> PopulateRecipes()
        {
            mockOrders.Add(new RecipeDto
            {
                name = "Authentic Mexican Chili Rellenos",
                author = "Kentucky Guera",
                calories = 263,
                type = RecipeType.MEXICAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
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
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/buffaloWings.jpg")
                : ImageSource.FromFile("Images/buffaloWings.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "Chocolate Lasagna",
                author = "Amanda Formaro",
                calories = 230,
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DESSERT.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chocolateLasagna.jpg")
                : ImageSource.FromFile("Images/chocolateLasagna.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "Pineapple Dream Dessert",
                author = "Amanda Formaro",
                calories = 376,
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DESSERT.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/pineappleDream.jpg")
                : ImageSource.FromFile("Images/pineappleDream.jpg")
            });
            mockOrders.Add(new RecipeDto
            {
                name = "No Bake Cheesecake Bites",
                author = "Julia",
                calories = 73,
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DESSERT.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/cheesecakeBites.jpg")
                : ImageSource.FromFile("Images/cheesecakeBites.jpg")
            });

            return mockOrders;
        }
    }
}
