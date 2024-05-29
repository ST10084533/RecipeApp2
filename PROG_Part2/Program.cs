using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_Part2
{
    public class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Recipe Application");
                Console.WriteLine("1. Add a recipe");
                Console.WriteLine("2. List all recipes");
                Console.WriteLine("3. Display recipe");
                Console.WriteLine("4. Scale recipe");
                Console.WriteLine("5. Reset recipe");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        recipeManager.AddRecipe();
                        break;
                    case "2":
                        recipeManager.ListRecipes();
                        break;
                    case "3":
                        recipeManager.DisplayRecipe();
                        break;
                    case "4":
                        recipeManager.ScaleRecipe();
                        break;
                    case "5":
                        recipeManager.ResetRecipeScale();
                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please Select a Valid Option!!!");
                        break;
                }
            }
        }
    }
}
    

