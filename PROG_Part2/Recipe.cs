using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG_Part2
{
    public class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }
        private List<Ingredient> OriginalIngredients { get; set; }

        public Recipe(string name)
        {
            Name = name;
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
            OriginalIngredients = new List<Ingredient>();
        }

        public void AddIngredient(Ingredient ingredient)
        {
            Ingredients.Add(ingredient);
            OriginalIngredients.Add(new Ingredient(ingredient.Name, ingredient.Quantity, ingredient.Unit, ingredient.Calories, ingredient.FoodGroup));
        }

        public void AddStep(string step)
        {
            Steps.Add(step);
        }

        public void Scale(double factor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= factor;
            }
        }

        public void ResetScale()
        {
            Ingredients = new List<Ingredient>(OriginalIngredients.Select(i => new Ingredient(i.Name, i.Quantity, i.Unit, i.Calories, i.FoodGroup)));
        }

        public int TotalCalories()
        {
            return Ingredients.Sum(i => i.Calories);
        }
    }
}

