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
        public List<RecipeDto> mockRecipes = new List<RecipeDto>();

        public Task<(List<Recipe> Recipes, bool IsSuccess)> GetRecipeDetails(string recipe)
        {
            if (mockRecipes.Count == 0)
            {
                PopulateRecipes();
            }

            var recipeDetails = mockRecipes.FindAll(x => x.name == recipe);
            return Task.FromResult((Mapper.Map<List<RecipeDto>, List<Recipe>>(recipeDetails), true));
        }

        public Task<(List<Recipe> Recipes, bool IsSuccess)> GetDessertRecipes()
        {
            if (mockRecipes.Count == 0)
            {
                PopulateRecipes();
            }

            var dessertRecipes = mockRecipes.FindAll(x => x.category == RecipeCategory.DESSERT.GetDescription());
            return Task.FromResult((Mapper.Map<List<RecipeDto>, List<Recipe>>(dessertRecipes), true));
        }

        public Task<(List<Recipe> Recipes, bool IsSuccess)> GetDinnerRecipes()
        {
            if (mockRecipes.Count == 0)
            {
                PopulateRecipes();
            }

            var dinnerRecipes = mockRecipes.FindAll(x => x.category == RecipeCategory.DINNER.GetDescription());
            return Task.FromResult((Mapper.Map<List<RecipeDto>, List<Recipe>>(dinnerRecipes), true));
        }

        public List<RecipeDto> PopulateRecipes()
        {
            mockRecipes.Add(new RecipeDto
            {
                name = "Authentic Mexican Chili Rellenos",
                author = "Kentucky Guera",
                ingredients = "\u2022 6 fresh Anaheim chile peppers:2 eggs separated:1 teaspoon baking powder:3/4 cup all-purpose flour:1 cup vegetable shortening for frying",

                directions = "Preheat the oven's broiler and set the oven rack at about 6 inches from the heat source. Line a baking sheet with aluminum foil. Place peppers onto the prepared baking sheet, and cook under the preheated broiler until the skin of the peppers has blackened and blistered, about 10 minutes. Turn the peppers often to blacken all sides. Place the blackened peppers into a bowl, and tightly seal with plastic wrap. Allow the peppers to steam as they cool, about 15 minutes." +
                ":Rinse cooled peppers under cold water to peel off the skins, and cut a slit along the long side of each pepper to remove the seeds and core. Rinse the peppers inside and out, and pat dry with paper towels. Stuff the peppers with strips of the cheese.,Whisk the egg yolks in a bowl with the baking powder. In a second metal bowl, beat the egg whites with an electric mixer until the whites form stiff peaks. Gently fold the beaten egg whites into the yolk mixture. Place flour into a shallow bowl." +
                ":Heat the vegetable shortening in a skillet over medium heat. Roll each stuffed pepper in flour, tap off excess flour, and dip the peppers into the egg mixture to coat both sides. Gently lay the coated peppers into the hot shortening. Fry peppers until lightly golden brown and the cheese has melted, about 5 minutes per side.",
                servings = "6",
                calories = 263,
                prepTime = "25m",
                cookTime= "20m",
                totalTime="1h",
                type = RecipeType.MEXICAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chiliRellenos.jpg")
                : ImageSource.FromFile("Images/chiliRellenos.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "Skinny Mexican Chicken Skillet",
                author = "Averie Sunshine",
                calories = 559,
                servings = "4",
                prepTime = "10m",
                cookTime = "10m",
                totalTime = "20m",
                ingredients = "\u2022 3 tablespoons olive oil:1 to 1.25 pounds boneless skinless chicken breast, diced into bite-sized pieces" +
                ":1 large/extra-large red bell pepper, diced small:1 medium sweet Vidalia or yellow onion, diced small:one 4-ounce can diced green chiles (I used fire-roasted)" +
                ":3 to 5 cloves garlic, finely minced or pressed:2 to 3 teaspoons cumin:1 teaspoon salt:1/2 teaspoon freshly ground black pepper" +
                ":pinch cayenne pepper, optional and to taste:one 15-ounce can black beans, drained and rinsed (I used no-salt added)" +
                ":1 to 1.5 cups corn (I used frozen; you can add it directly to the skillet from the freezer):2 tablespoons green onions:fresh cilantro, for garnishing",

                directions = "To a large skillet, add the oil, chicken, red pepper, onion, and sauté over medium-high heat for about 7 to 8 minutes, or until chicken is cooked through and vegetables have softened. Stir and flip frequently to ensure even cooking." +
                ":Add the green chiles, garlic, cumin, salt, pepper, optional cayenne, stir to combine, and cook for about 1 minute or until the garlic is fragrant." +
                ":Add the black beans, corn, stir, and cook for about 1 minute, or until warmed through." +
                ":Evenly sprinkle the green onions, cilantro, and serve immediately. Recipe will keep airtight in the fridge for up to 5 days or in the freezer for up to 4 months.",
                type = RecipeType.MEXICAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/skinnyMexicanChicken.jpg")
                : ImageSource.FromFile("Images/skinnyMexicanChicken.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "Chicken Fajitas",
                author = "Isabel Eats",
                calories = 263,
                servings = "8",
                prepTime = "14m",
                cookTime = "16m",
                totalTime = "30m",
                ingredients = "\u2022 2 pounds boneless skinless chicken breast, sliced into thin strips:1/4 cup chopped cilantro" +
                ":2 tablespoons lime juice (juice of 1 lime):1 tablespoon cooking oil:1 tablespoon minced garlic (about 3 cloves)" +
                ":1 tablespoon chili powder:1 teaspoon ground cumin:1 teaspoon dried oregano:1/2 teaspoon coarse kosher salt" +
                ":pinch cayenne pepper, optional and to taste:one 15-ounce can black beans, drained and rinsed (I used no-salt added)" +
                ":1/2 teaspoon paprika:1/2 teaspoon ancho chili powder:2 tablespoons cooking oil, divided:2 bell peppers, sliced into strips" +
                ":1 large poblano pepper sliced into strips (or substitute with another bell pepper if you can't find poblanos):1/2 large onion, sliced:1 pinch salt",

                directions = "Add all the ingredients for the quick marinade in a large mixing bowl. Toss together until chicken is evenly coated with spices. Cover and set aside." +
                ":In a large skillet over medium-high heat, add 1 tablespoon of cooking oil. Add the peppers, onions and a pinch of salt. Cook, stirring occasionally, for about 8 minutes, until the veggies are soft." +
                ":Add the remaining tablespoon of cooking oil to the same skillet. Add the marinated chicken and cook for 8 to 10 minutes, until chicken is fully cooked." +
                ":Add the peppers and onions back to the skillet, toss together with the chicken and remove from heat." +
                ":Serve in warm flour or corn tortillas and top with sour cream, guacamole and chopped cilantro.",
                type = RecipeType.MEXICAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chickenFajitas.jpg")
                : ImageSource.FromFile("Images/chickenFajitas.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "Healthy Mexican Casserole",
                author = "Kathi & Rachel",
                calories = 267,
                servings = "6",
                prepTime = "15m",
                cookTime = "15m",
                totalTime = "30m",
                ingredients = "\u2022 1 pound ground chicken or turkey we really love ground chicken if you can find it:2 teaspoons olive oil" +
                ":1 small poblano pepper, seeded and chopped:1 small red pepper, chopped:1/2 cup onion, chopped:2 teaspoons cumin" +
                ":1 tablespoon chili powder:1/2 teaspoon salt:4 8 inch flour tortillas cut into quarters:1 16 ounce can fat free refried beans" +
                ":1/4 teaspoon ground pepper:1 10 ounce can enchilada sauce we used mild to make it family friendly:1/2 cup corn fresh, frozen or canned" +
                ":1/2 cup black beans drained and rinsed:1/2 cup grated cheese",

                directions = "Preheat oven to 375 degrees. In large skillet heat olive oil. Brown ground chicken, breaking up into small pieces as you go along. Drain any excess liquid." +
                ":Add chopped peppers and onions to browed chicken and cook until softened but not overly cooked. About 5 minutes. Add corn, black beans and spices. Heat through." +
                ":Spray a 9 x 9 inch baking pan with non stick spray.  Line bottom of pan with quartered tortillas." +
                ":Put the refried beans in a small bowl and heat in the microwave for 30 seconds. Stir to soften. Spread on top of tortillas." +
                ":Add cooked meat and veggies on top of refried beans. Pour enchilada sauce over the top." +
                ":Sprinkle with cheese and bake for 15-20 minutes until hot in the middle and bubbling around the edges." +
                ":Serve with fresh avocado and sour cream.",
                type = RecipeType.MEXICAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/mexicanCasserole.jpg")
                : ImageSource.FromFile("Images/mexicanCasserole.jpg")
            });

            mockRecipes.Add(new RecipeDto
            {
                name = "Italian Skillet Chicken with Tomatoes and Mushrooms",
                author = "Suzy",
                calories = 218,
                servings = "4",
                prepTime = "10m",
                cookTime = "20m",
                totalTime = "30m",
                ingredients = "\u2022 4 large chicken cutlets (boneless skinless chicken breasts cut into 1/4-inch thin cutlets):1 tbsp dried oregano, divided" +
                ":1 tsp salt, divided:1 tsp black pepper, divided:1/2 cup all-purpose flour, more for later:Private Reserve Extra Virgin Olive Oil " +
                ":8 oz Baby Bella mushrooms, cleaned, trimmed, and sliced:14 oz grape tomatoes, halved:2 tbsp chopped fresh garlic:1/2 cup white wine" +
                ":1 tbsp freshly squeezed lemon juice (juice of 1/2 lemon):3/4 cup chicken broth:Handful baby spinach (optional)",

                directions = "Pat chicken cutlets dry. Season on both sides with 1/2 tbsp dried oregano, 1/2 tsp salt and 1/2 tsp black pepper. Coat the chicken cutlets with the flour; dust off excess. Set aside briefly." +
                ":Heat 2 tbsp olive oil in a large cast iron skillet with a lid like this one. Brown the chicken cutlets on both sides (3 minutes or so). Transfer the chicken cutlets to a plate for now." +
                ":In the same skillet, add more olive oil if needed. Add the mushrooms and saute briefly on medium-high (about 1 minute or so). Then add the tomatoes, garlic, the remaining 1/2 tbsp oregano, 1/2 tsp salt, and 1/2 tsp pepper, and 2 tsp flour. Cook for another 3 minutes or so, stirring regularly." +
                ":Now add the white wine, cook briefly to reduce just a little; then add the lemon juice and chicken broth." +
                ":Bring the liquid to a boil, then add the chicken back in the skillet. Cook over high heat for 3-4 minutes, then reduce the heat to medium-low. Cover and cook for another 8 minutes or until the chicken is fully cooked and its internal heat registers a minimum of 165 degrees F." +
                ":If you like, stir in a handful of baby spinach just before serving. Enjoy hot with your favorite small pasta like orzo and a crusty Italian bread!",
                type = RecipeType.ITALIAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/italianSkillet.jpg")
                : ImageSource.FromFile("Images/italianSkillet.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "Stuffed Shells With Ricotta and Spinach Recipe",
                author = "Daniel Gritzer",
                calories = 450,
                servings = "4-6",
                prepTime = "15m",
                cookTime = "60m",
                totalTime = "1h 15m",
                ingredients = "\u2022 6 ounces dry jumbo pasta shells (about 25 shells; see note):Kosher salt" +
                ":Extra-virgin olive oil, for drizzling and greasing the baking dish:10 ounces (280g) tender fresh greens, such as arugula, spinach, or a combination:" +
                ":1 pound (450g) good quality ricotta, such as Calabro or from a local Italian dairy:12 ounces (340g) fresh or low-moisture mozzarella, shredded, divided" +
                ":2 ounces (55g) grated Parmigiano-Reggiano cheese, divided:1 medium clove garlic, minced:Pinch freshly grated nutmeg:Freshly ground black pepper" +
                ":1 1/2 cups (355ml) tomato sauce, such as Quick Tomato Sauce, Fresh Tomato Sauce, or Slow Cooked Tomato Sauce, divided",

                directions = "Preheat oven to 375°F. In a large pot of salted boiling water, cook shells according to package instructions for baked shells (many packages of jumbo shells will give a specific boiling time for dishes that are subsequently baked; if not, cook the shells for 3 minutes fewer than the stated cooking time). Using a spider, slotted spoon, or mesh strainer, carefully transfer shells to a large bowl of cold water until cooled slightly, then drain. Drizzle shells very lightly with oil and toss to coat. Set aside." +
                ":In the same pot of water, cook the greens until fully wilted, about 30 seconds. Drain greens into the bowl of a salad spinner set in the sink. Run under cold water until thoroughly chilled, then spin in salad spinner to dry." +
                ":Spread greens over a clean kitchen towel or a double layer of paper towels and roll into a tight tube, pressing to remove excess moisture. Transfer to a cutting board and roughly chop." +
                ":Line a large plate or a rimmed baking sheet with a triple layer of paper towels or a clean kitchen towel. Spread ricotta on top and cover with more paper towels or another clean kitchen towel. Let drain for 5 minutes, then remove towels and transfer ricotta to a large bowl. (You may need to use a spatula to scrape all of the ricotta off the towels.)" +
                ":Add spinach, 8 ounces shredded mozzarella, 1 1/2 ounces grated Parmigiano-Reggiano, garlic, and nutmeg to ricotta. Season with salt and pepper and mix well." +
                ":Lightly grease a 9- by 13-inch baking dish with oil. Spread 1/2 cup tomato sauce in an even layer on bottom of baking dish. Using a spoon, fill each shell with a large scoop of ricotta filling and place opening side up in baking dish. Repeat until baking dish is full (you should be able to fit about 18 stuffed shells in the dish, and may have a few pasta shells leftover)." +
                ":Spoon the remaining 1 cup tomato sauce on top of shells. Top with remaining 4 ounces shredded mozzarella and 1/2 ounce grated Parmigiano-Reggiano cheese." +
                ":Bake until shells are heated through and cheese is bubbling and lightly browned on top, about 40 minutes. Let cool slightly, then serve.",
                type = RecipeType.ITALIAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/stuffedShells.jpg")
                : ImageSource.FromFile("Images/stuffedShells.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "Chicken Marsala",
                author = "Sabrina Snyder",
                calories = 460,
                servings = "4",
                prepTime = "5m",
                cookTime = "15m",
                totalTime = "20m",
                ingredients = "\u2022 2 chicken breasts, boneless and skinless:1/3 cup flour for coating:1/2 teaspoon kosher salt:1/4 teaspoon coarse ground black pepper" +
                ":1/3 cup unsalted butter:4 tablespoons olive oil:8 ounces sliced mushrooms:1/2 cup chicken stock, (or chicken broth):1/2 cup Marsala wine",

                directions = "Cut the chicken breasts in half, butterflied to make four thinner chicken breast pieces." +
                ":Mix together the flour, salt and pepper then coat the chicken pieces in it." +
                ":Add the butter and olive oil to a large skillet on medium high heat and cook the chicken in it 4 - 5 minutes on each side until golden brown." +
                ":Remove the chicken from the pan, add in the mushrooms and cook for 3 - 4 minutes until browned." +
                ":Add the chicken back in, pour in the chicken stock and wine and let simmer for 10 minutes before serving.",
                type = RecipeType.ITALIAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chickenMarsala.jpg")
                : ImageSource.FromFile("Images/chickenMarsala.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "Chop Suey",
                author = "Kathleen",
                calories = 646,
                servings = "8",
                prepTime = "1h",
                cookTime = "55m",
                totalTime = "1h 55m",
                ingredients = "\u2022 3 Tablespoon Butter:1 Large Yellow Onion Finely Chopped:1 Green Pepper Seeded and Finely Chopped:1 Tablespoon Fresh Garlic minced" +
                ":2 Pounds Ground Beef 80 / 20:1 1 / 2 Teaspoon Salt:1 / 2 Teaspoon Black Pepper:2 15 Ounce - Each Cans Tomato Sauce:1 28 Ounce Can Crushed Tomatoes, Including All Liquid" +
                ":3 Cups Water:1 Tablespoon Worcestershire Sauce:1 Teaspoon Paprika:2 Teaspoon Sugar:1 Tablespoon Dried Italian Seasoning:2 Cups Elbow Macaroni Uncooked" +
                ":16 Ounces Mozzarella Shredded:2 - 3 Tablespoons Italian Parsley Roughly Chopped (Optional)",

                directions = "Cut the chicken breasts in half, butterflied to make four thinner chicken breast pieces." +
                ":Mix together the flour, salt and pepper then coat the chicken pieces in it." +
                ":Add the butter and olive oil to a large skillet on medium high heat and cook the chicken in it 4 - 5 minutes on each side until golden brown." +
                ":Remove the chicken from the pan, add in the mushrooms and cook for 3 - 4 minutes until browned." +
                ":Add the chicken back in, pour in the chicken stock and wine and let simmer for 10 minutes before serving.",
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chopSuey.jpg")
                : ImageSource.FromFile("Images/chopSuey.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "All American Chili",
                author = "McCormick",
                calories = 310,
                servings = "5",
                prepTime = "5m",
                cookTime = "25m",
                totalTime = "30m",
                ingredients = "\u2022 1 pound lean ground beef:1 cup chopped onion:2 tablespoons McCormick® Chili Powder:2 teaspoons McCormick® Cumin, Ground" +
                ":1 1 / 2 teaspoons McCormick® Garlic Salt:1 / 2 teaspoon McCormick® Oregano Leaves:1 can(15 ounces) kidney beans,drained" +
                ":1 can(14 1 / 2 ounces) diced tomatoes:1 can(8 ounces) tomato sauce",

                directions = "Cook ground beef and onion in large skillet on medium-high heat until beef is no longer pink, stirring occasionally. Drain fat, if needed." +
                ":Stir in spices and remaining ingredients. Bring to boil. Reduce heat to low; cover and simmer 20 minutes, stirring occasionally." +
                ":Serve with shredded cheese, sour cream and chopped onion, if desired.",
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chili.jpg")
                : ImageSource.FromFile("Images/chili.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "Crock pot American Goulash",
                author = "Eating on a Dime",
                calories = 718,
                servings = "6",
                prepTime = "15m",
                cookTime = "6h 15m",
                totalTime = "6h 30m",
                ingredients = "\u2022 2 pounds ground beef:1 / 2 onion diced:1 green bell pepper diced:2 teaspoon minced garlic:1 teaspoon salt" +
                ":1 teaspoon pepper:1 teaspoon Italian Seasoning:2 can crushed tomatoes 14.5 oz:1 can diced tomatoes 14.5 0z" +
                ":3 cups beef broth:3 cups dry uncooked macaroni",

                directions = "In a skillet over medium heat, cook ground beef until it is brown. Add to a 6 quart slow cooker.:" +
                ":Add in bell pepper, Italian Seasoning, salt, pepper, tomatoes, and broth. Stir to combine." +
                ":Cover and cook on low for 6-8 hours or high for 3-4." +
                ":15 minutes before serving stir in the pasta. It will look very watery but don't worry the pasta will soak it up. Cover and cook for 15 minutes until the desired tenderness is reached." +
                ":Serve immediately.",
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/goulash.jpg")
                : ImageSource.FromFile("Images/goulash.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "All-American Potato Salad",
                author = "Jessica Gavin",
                calories = 200,
                servings = "6",
                prepTime = "10m",
                cookTime = "25m",
                totalTime = "55m",
                ingredients = "\u2022 2 pounds russet potatoes:1 tablespoon kosher salt, for cooking potatoes:2 tablespoons distilled white vinegar:1 / 2 cup celery, 1 / 8 - inch dice" +
                ":1 / 2 cup mayonnaise:1 / 4 cup dill pickle relish:2 tablespoons red onions, 1 / 8 - inch dice:2 tablespoons minced parsley" +
                ":1 1 / 2 teaspoons dijon mustard, or yellow mustard:3 / 4 teaspoons kosher salt:1 / 2 teaspoon black pepper" +
                ":1 / 2 teaspoon onion powder:2 hard boiled eggs, diced into 1 / 4 cubes",

                directions = "Peel the potatoes and cut them into 3/4-inch dice. Immediately place them in a large saucepan and add enough water to cover by 1 inch." +
                ":Boil water over medium-high heat." +
                "Add 1 tablespoon salt, reduce heat to medium, and simmer. Stir a few times, until potatoes are fork tender, about 8 minutes." +
                ":Drain potatoes and transfer back to the pot." +
                ":Add vinegar and use a rubber spatula to toss gently to combine. Let stand for 20 minutes, the potatoes will still be warm." +
                ":In a large bowl, gently stir together potatoes, celery, mayonnaise, relish, onion, parsley, mustard, ¾ teaspoon salt, ½ teaspoon pepper, onion powder and chopped eggs. Add more salt and pepper to taste." +
                ":Cover and refrigerate until chilled, about 1 hour before serving. Garnish with more parsley, celery, and onion if desired.",
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/potatoSalad.jpg")
                : ImageSource.FromFile("Images/potatoSalad.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "Buffalo Chicken",
                author = "Emma Freud",
                calories = 520,
                servings = "4",
                prepTime = "20m",
                cookTime = "1h 5m",
                totalTime = "1h 25m",
                ingredients = "\u2022 1½ kg chicken thighs and drumsticks:180g sea salt flakes:90g soft dark brown sugar:2 tbsp chilli flakes" +
                "2 tbsp sweet smoked paprika:1 tbsp ground cumin:1 tbsp sea salt flakes:1 tbsp dark brown sugar" +
                "75g butter:125ml hot chilli sauce:1 tbsp maple syrup",

                directions = "Put the chicken in a big bowl. In a pan, heat 1 litre of water with the salt, brown sugar and chilli flakes. When it’s dissolved, add 2 litres of cold water and pour over the chicken. Put in the fridge and leave for at least 2 hrs, but ideally a day or two. When you’re ready to cook, take the chicken out of the water and pat dry all over with kitchen paper." +
                ":Heat oven to 180C/160C fan/gas 4. Put the smoked paprika, ground cumin, sea salt and dark brown sugar on a baking tray. Mix them together, then roll the dried chicken pieces in the spices, making sure everything is covered. Roast the chicken for 1 hr or until crispy and caramelised." +
                ":Meanwhile, for the sauce, gently melt the butter in a small pan with the hot sauce and maple syrup. When the chicken pieces come out of the oven, drizzle this sauce all over them and give them a shake. Serve with a side of creamed corn.",
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DINNER.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/buffaloWings.jpg")
                : ImageSource.FromFile("Images/buffaloWings.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "Chocolate Lasagna",
                author = "Amanda Formaro",
                calories = 230,
                servings = "4",
                prepTime = "30m",
                cookTime = "0m",
                totalTime = "30m",
                ingredients = "\u2022 1 package Oreos 36 regular cookies (do not remove cream centers):6 Tablespoons butter melted:1 8 oz cream cheese room temp" +
                ":1 / 4 cup granulated sugar:2 3 / 4 cups milk 1 %:2 tablespoons milk 1 %:2 8 oz Cool Whip non - fat(2 8 - ounce containers)" +
                ":2 3.9 oz instant chocolate pudding:3 / 4 cup miniature chocolate chips",

                directions = "Use a food processor (or a zip top bag and a rolling pin) to crush the Oreos into fine crumbs." +
                ":Into a medium bowl, pour in the cookie crumbs and melted butter. Stir until thoroughly mixed." +
                ":Pour into a 9 x 13 baking dish and use a spatula (or the bottom of a measuring cup) to evenly press the crumbs across the dish." +
                ":In the same medium bowl, add the cream cheese and beat with a hand mixer until fluffy. Add in the 2 Tablespoons of milk and sugar and mix well." +
                ":Fold the contents of one of the 8 oz Cool Whip containers into the cream cheese mixture." +
                ":Spread the cream cheese mixture over the cookie crust and pop it into the fridge to set for about 10 minutes." +
                ":While it's setting, to a large bowl, add the pudding mixes and 2 3/4 cups milk and beat on medium until it starts to thicken." +
                ":Spread the pudding mixture over the cream cheese layer. Put back into the fridge to set for another 10 minutes." +
                ":Once set, gently spread the remaining 8 oz of Cool Whip over the top and sprinkle with mini chocolate chips." +
                ":Cover with plastic wrap and let chill for at least 4 hours in the fridge or 1 hour in the freezer before you slice.",
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DESSERT.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/chocolateLasagna.jpg")
                : ImageSource.FromFile("Images/chocolateLasagna.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "Pineapple Dream Dessert",
                author = "Amanda Formaro",
                calories = 376,
                servings = "4",
                prepTime = "30m",
                cookTime = "0m",
                totalTime = "30m",
                ingredients = "\u2022 1 package Oreos 36 regular cookies (do not remove cream centers):6 Tablespoons butter melted:1 8 oz cream cheese room temp" +
                ":1 / 4 cup granulated sugar:2 3 / 4 cups milk 1 %:2 tablespoons milk 1 %:2 8 oz Cool Whip non - fat(2 8 - ounce containers)" +
                ":2 3.9 oz instant chocolate pudding:3 / 4 cup miniature chocolate chips",

                directions = "Use a food processor (or a zip top bag and a rolling pin) to crush the Oreos into fine crumbs." +
                ":Into a medium bowl, pour in the cookie crumbs and melted butter. Stir until thoroughly mixed." +
                ":Pour into a 9 x 13 baking dish and use a spatula (or the bottom of a measuring cup) to evenly press the crumbs across the dish." +
                ":In the same medium bowl, add the cream cheese and beat with a hand mixer until fluffy. Add in the 2 Tablespoons of milk and sugar and mix well." +
                ":Fold the contents of one of the 8 oz Cool Whip containers into the cream cheese mixture." +
                ":Spread the cream cheese mixture over the cookie crust and pop it into the fridge to set for about 10 minutes." +
                ":While it's setting, to a large bowl, add the pudding mixes and 2 3/4 cups milk and beat on medium until it starts to thicken." +
                ":Spread the pudding mixture over the cream cheese layer. Put back into the fridge to set for another 10 minutes." +
                ":Once set, gently spread the remaining 8 oz of Cool Whip over the top and sprinkle with mini chocolate chips." +
                ":Cover with plastic wrap and let chill for at least 4 hours in the fridge or 1 hour in the freezer before you slice.",
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DESSERT.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/pineappleDream.jpg")
                : ImageSource.FromFile("Images/pineappleDream.jpg")
            });
            mockRecipes.Add(new RecipeDto
            {
                name = "No-bake Cheesecake Bites With Graham Cracker Crust",
                author = "Tracy",
                calories = 103,
                servings = "16",
                prepTime = "10m",
                cookTime = "0m",
                totalTime = "4h 10m",
                ingredients = "\u2022 3 tablespoons (1.5oz) butter:1 / 2 cup graham cracker crumbs 3 full graham cracker sheets:1 heaping tablespoon(16g) brown sugar" +
                ":3 tablespoons heavy cream:3 ounces cream cheese softened:2 heaping tablespoons(32g) granulated sugar:1 / 2 teaspoon vanilla extract" +
                ":1/2 cup (3oz) chopped semi-sweet chocolate (good quality chips are fine):2 teaspoons refined coconut oil or vegetable oil",

                directions = "Line your mini muffin pan with 16 liners and clear enough space in your freezer to fit the pan." +
                ":In a medium, microwave-safe bowl, melt butter. Stir in graham cracker crumbs and brown sugar until mixture begins to clump. Drop a heaping teaspoon of the crust into each of the prepared muffin cups. If there are leftover crumbs, distribute them between the cups (or eat them 😉 ). Use the top of a wooden spoon or bottom of a shot glass to firmly pack the crumbs into the cups." +
                ":Pour heavy cream into a small bowl and use a handheld electric mixer, starting on low, working up to high to beat cream until stiff peaks form." +
                ":In a medium bowl, combine softened cream cheese, sugar, and vanilla. Beat until well-mixed and fluffy." +
                ":Fold whipped cream into cream cheese mixture until no streaks remain, being careful not to deflate the whipped cream as best you can. Transfer mixture to a piping bag or disposable plastic bag and snip off a corner of the bag. Use the bag to pipe the cheesecake mixture into the muffin cups, filling them about 3/4 of the way full and smoothing the top of each cheesecake as you go." +
                ":Place cheesecakes in the freezer and freeze for 10 to 15 minutes, until just set." +
                ":In a small, microwave-safe bowl, combine chocolate and coconut oil. Microwave for 30 seconds and stir until smooth. If necessary, microwave in 15-second increments until melted. Use a teaspoon to drop spoonfuls of chocolate over the cheesecakes until all the tops are covered and chocolate is gone." +
                ":Freeze for 3 to 4 hours until completely solid. Remove cheesecakes from tray (leave wrappers on) and store in an airtight container or freezer bag in the freezer for up to a month.",
                type = RecipeType.AMERICAN.GetDescription(),
                category = RecipeCategory.DESSERT.GetDescription(),
                image = Device.RuntimePlatform == Device.Android
                ? ImageSource.FromFile("drawable/cheesecakeBites.jpg")
                : ImageSource.FromFile("Images/cheesecakeBites.jpg")
            });

            return mockRecipes;
        }
    }
}
