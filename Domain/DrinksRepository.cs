using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Domain
{

    public interface IDrinksRepository
    {
        IEnumerable<Drink> GetAllDrinks();
        Drink GetDrinkByName(string drinkName);
        // Other methods for managing drinks in the data source
    }
    public class DrinksRepository : IDrinksRepository
    {
        private readonly List<Drink> Drinks = new List<Drink>(); // Simulated in-memory data store
        private readonly IConfiguration _configuration;

        public DrinksRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IEnumerable<Drink> GetAllDrinks()
        {
            var drinks = _configuration.GetSection("Drinks").Get<List<Drink>>();
            return drinks;
        }

        public Drink GetDrinkByName(string drinkName)
        {
            var drinks = _configuration.GetSection("Drinks").Get<List<Drink>>();
            var selectedDrink = drinks.Find(drink => drink.Name == drinkName);
            // List<IngredientConfig> adjustableIngredients = new List<IngredientConfig>();
            if (selectedDrink != null)
            {
            //     // Console.WriteLine($"Found drink: {selectedDrink.Name}");
                foreach (IngredientConfig ingredient in selectedDrink.Ingredients)
                {
            //         Console.WriteLine($"- Ingredient: {ingredient.Name}, Quantity: {ingredient.Quantity}, HotWaterVolume: {ingredient.HotWaterVolume}, HotWaterTemp: {ingredient.HotWaterTemp}");
            //      check if any of the ingredient is adjustable
                    if (ingredient.AdjustableStrength)
                    {
            //             adjustableIngredients.Add(ingredient);
                        selectedDrink.Adjustable = true;
                    }
                }
            }
            return selectedDrink;
        }
        // public List<Drink> Drinks { get; set; }
    }

}