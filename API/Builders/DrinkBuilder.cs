#pragma warning disable CS8618 // Non-nullable property is uninitialized. Consider declaring as nullable.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoffeeDrinksBuilderApp.Models;

namespace CoffeeDrinksBuilderApp.Builders
{
    public interface IDrinkBuilder
    {
        void Reset();
        void AddIngredient(string name, int quantity);
        void SetDesiredStrength(string ingredientName, int desiredStrength);
        // Other methods for configuring drink properties
        Drink GetDrink();
    }

    public class DrinkBuilder : IDrinkBuilder
    {
        private Drink drink;

        public DrinkBuilder()
        {
            Reset();
        }

        public void Reset()
        {
            drink = new Drink();
            // Initialize default values or reset the object
        }

        public void SetDrinkName(string name)
        {
            drink.Name = name;
        }

        public void AddIngredient(string name, int quantity)
        {
            // Add ingredient with quantity to the drink
            // Implement logic to add ingredients to the drink
        }

        public void SetDesiredStrength(string ingredientName, int desiredStrength)
        {
            // Set desired strength for a specific ingredient in the drink
            // Implement logic to set desired strength for an ingredient
        }

        public Drink GetDrink()
        {
            return drink;
        }
    }
}