using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_Part2
{
    public delegate void CalorieNotification(int totalCalories);
    public class RecipeManager
    {
        private List<Recipe> recipes;

        public RecipeManager()
        {
            recipes = new List<Recipe>();
        }

        public void AddRecipe()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Enter the name of the recipe: ");
            string name = Console.ReadLine();
            Recipe recipe = new Recipe(name);

            bool addingIngredients = true;
            while (addingIngredients)
            {
                Console.Write("Enter ingredient name (or 'complete' to finish): ");
                string ingredientName = Console.ReadLine();
                if (ingredientName.ToLower() == "complete")
                {
                    addingIngredients = false;
                    break;
                }

                Console.Write("Enter quantity: ");
                double quantity = double.Parse(Console.ReadLine());

                Console.Write("Enter unit: ");
                string unit = Console.ReadLine();

                Console.Write("Enter calories: ");
                int calories = int.Parse(Console.ReadLine());

                Console.Write("Enter food group (Carbohydrates, Protein, Fat and Sugar, Fruits and Vegetables or Dairy): ");
                string foodGroup = Console.ReadLine();

                recipe.AddIngredient(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
            }

            bool addingSteps = true;
            while (addingSteps)
            {
                Console.Write("Enter step (or 'complete' to finish): ");
                string step = Console.ReadLine();
                if (step.ToLower() == "complete")
                {
                    addingSteps = false;
                    break;
                }
                recipe.AddStep(step);
            }

            recipes.Add(recipe);
        }

        public void ListRecipes()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Recipes:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
        }

        public void DisplayRecipe()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write("Enter the name of the recipe to view: ");
            string name = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                Console.WriteLine($"Recipe: {recipe.Name}");
                Console.WriteLine("Ingredients:");
                foreach (var ingredient in recipe.Ingredients)
                {
                    Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} {ingredient.Name} - {ingredient.Calories} calories ({ingredient.FoodGroup})");
                }
                Console.WriteLine("Steps:");
                for (int i = 0; i < recipe.Steps.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
                }

                int totalCalories = recipe.TotalCalories();
                Console.WriteLine($"Total Calories: {totalCalories}");
                if (totalCalories > 300)
                {
                    NotifyCalorieExcess(totalCalories);
                }
            }
            else
            {
                Console.WriteLine("This Recipe does not Exist!!!");
            }
        }

        public void ScaleRecipe()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor= ConsoleColor.Yellow;

            Console.Write("Enter the name of the recipe to scale: ");
            string name = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                Console.Write("Enter scale factor (0.5, 2, 3): ");
                double factor = double.Parse(Console.ReadLine());

                recipe.Scale(factor);
                Console.WriteLine($"Recipe {recipe.Name} has been scaled by a factor of {factor}.");
            }
            else
            {
                Console.WriteLine("This Recipe does not Exist!!!");
            }
        }

        public void ResetRecipeScale()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.Write("Enter the name of the recipe to reset: ");
            string name = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.ResetScale();
                Console.WriteLine($"Recipe {recipe.Name} has been reset to its original quantities.");
            }
            else
            {
                Console.WriteLine("This Recipe does not Exist!!!");
            }
        }

        private void NotifyCalorieExcess(int totalCalories)
        {
            CalorieNotification calorieNotification = delegate (int calories)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine($"WARNING: Total Calories exceed 300!!! Current total is: {calories}");
            };
            calorieNotification(totalCalories);
        }
    }
}

