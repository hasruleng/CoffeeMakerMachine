#pragma warning disable CS8618 // Non-nullable property is uninitialized. Consider declaring as nullable.

using Domain;
using Microsoft.Extensions.Logging;

namespace Application
{
    public interface IDrinkBuilder
    {
        void Reset();
        void SetDrink(Drink drink);
        void MakeDrink();
    }

    public class DrinkBuilder : IDrinkBuilder
    {
        private readonly ILogger<DrinkMachineService> _logger;

        private Drink drink;

        public DrinkBuilder(ILogger<DrinkMachineService> logger)
        {
            _logger = logger;
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

        public void SetDrink(Drink drink)
        {
            this.drink = drink;
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

        public void MakeDrink()
        {
            foreach (IngredientConfig ingredient in drink.Ingredients)
            {
                _logger.LogInformation($"Filling the cup with: {ingredient.Name}, Quantity: {ingredient.Quantity}, HotWaterVolume: {ingredient.HotWaterVolume}, HotWaterTemp: {ingredient.HotWaterTemp}");
            }
            _logger.LogInformation("Please take your cup of " + drink.Name + ". Thank you.");
        }
    }
}