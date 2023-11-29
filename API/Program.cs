using System;
using CoffeeDrinksBuilderApp.Builders;
using System.Text.Json;
using CoffeeDrinksBuilderApp.Models;
using System.Runtime.InteropServices;

namespace CoffeeMachineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string configFilePath = "Configuration/drink_options.json";
            // string jsonString = File.ReadAllText(configFilePath);
            // var config = JsonSerializer.Deserialize<DrinkConfig>(jsonString);

            IDrinkOptionsLoader loader = new ConfigFile_DrinkOptionsLoader();
            var drinksConfig = loader.LoadFrom(configFilePath);

            //check the DrinkConfig data
            foreach (var drink in drinksConfig.Drinks)
            {
                Console.WriteLine($"Drink Name: {drink.Name}");
                foreach (var ingredient in drink.Ingredients)
                {
                    Console.WriteLine($"- Ingredient: {ingredient.Name}, Quantity: {ingredient.Quantity}");
                    // Print other ingredient properties
                }
                Console.WriteLine(); // For separation between drinks
            }

            //lets start the builder here
            
        }
    }
}
