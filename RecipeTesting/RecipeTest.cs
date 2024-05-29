using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROG_Part2;
using System;

namespace RecipeTesting
{
    [TestClass]
    public class RecipeTest
    {
        [TestMethod]
        public void TestingTotalCalories()
        {
            Recipe recipe = new Recipe("Test Recipe");
            recipe.AddIngredient(new Ingredient("Sugar", 100, "grams", 400, "Fat and Sugar"));
            recipe.AddIngredient(new Ingredient("Butter", 50, "grams", 200, "Fat and Sugar"));

            int totalCalories = recipe.TotalCalories();
            Assert.AreEqual(600, totalCalories);
        }
    }
    
}
