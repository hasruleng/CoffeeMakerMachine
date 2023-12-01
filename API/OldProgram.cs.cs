using System;
using CoffeeDrinksBuilderApp.Builders;
using System.Text.Json;
using Domain;
using System.Runtime.InteropServices;
using System.Reflection;

namespace CoffeeMachineApp
{
    class Program
    {
        static void Main(string[] args) //this is like the Controller class (contain endpoints) in Web API project
        {
            string configFilePath = "Configuration/drink_options.json";
            // string jsonString = File.ReadAllText(configFilePath);
            // var config = JsonSerializer.Deserialize<DrinksRepository>(jsonString);

            IDrinkOptionsLoader loader = new ConfigFile_DrinkOptionsLoader();
            DrinksRepository drinksConfig = loader.LoadFrom(configFilePath);

            //1: SELECTING THE DRINK
            string? selection = null;
            if (args.Length > 0)
            {
                selection = args[0];
                Console.WriteLine("Selection:", selection);
            }
            else
            {
                Console.WriteLine("Please type a drink of your choice, then press Enter");
                selection = Console.ReadLine();
                // Environment.Exit(0);
            }

            Drink selectedDrink = drinksConfig.GetDrinkByName(selection);
            List<IngredientConfig> adjustableIngredients = new List<IngredientConfig>();
            if (selectedDrink != null)
            {
                Console.WriteLine($"Found drink: {selectedDrink.Name}");
                foreach (IngredientConfig ingredient in selectedDrink.Ingredients)
                {
                    Console.WriteLine($"- Ingredient: {ingredient.Name}, Quantity: {ingredient.Quantity}, HotWaterVolume: {ingredient.HotWaterVolume}, HotWaterTemp: {ingredient.HotWaterTemp}");
                    //check if any of the ingredient is adjustable
                    if (ingredient.AdjustableStrength)
                    {
                        adjustableIngredients.Add(ingredient);
                        selectedDrink.Adjustable = true;
                    }
                }
            }
            else
                Console.WriteLine("There is no " + selection + " drink here!");

            //2: SELECTING THE DRINK OPTIONS(if applicable)
            if (selectedDrink.Adjustable)
                Console.WriteLine("You can adjust your " + selectedDrink.Name + "...");
            foreach (var ingredient in adjustableIngredients)
            {
                Console.WriteLine($"- Ingredient: {ingredient.Name}, DefaultStrength: {ingredient.DefaultStrength}");
                Console.WriteLine("Choose new strength: from 1 to 5 or just press enter to use the DefaultStrength");
                var userInput = Console.ReadLine();
                var newStrength = -1;
                if (string.IsNullOrEmpty(userInput))
                {
                    Console.WriteLine("No change in "+ingredient.Name+", using the DefaultStrength");
                }
                else if (int.TryParse(userInput, out newStrength) && newStrength >= 1 && newStrength <= 5)
                {
                    Console.WriteLine(ingredient.Name + "strength is now: " + newStrength 
                    + ". Doing calculation for the new " + ingredient.Name + " quantity");
                    double percentage = (double)newStrength/ingredient.DefaultStrength;
                    ingredient.Quantity = (int) (ingredient.Quantity * percentage);
                    Console.WriteLine($"- Ingredient: {ingredient.Name}, UPDATED QUANTITY: {ingredient.Quantity}");
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 5.");
                }
            }

            //3: BUILD (MAKE) THE DRINK HERE
            IDrinkBuilder drinkBuilder = new DrinkBuilder();

            drinkBuilder.SetDrink(selectedDrink);
            drinkBuilder.MakeDrink();

        }
    }
}
