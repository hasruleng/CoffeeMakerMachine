using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using CoffeeDrinksBuilderApp.Models;

namespace CoffeeDrinksBuilderApp.Builders
{
    public interface IDrinkOptionsLoader {
        public DrinkConfig LoadFrom(string Someparam);
    }
    
    //concrete implementation that reads JSON file
    public class ConfigFile_DrinkOptionsLoader : IDrinkOptionsLoader
    {
        public DrinkConfig LoadFrom(string configFile)
        {
            string jsonString = File.ReadAllText(configFile);
            return JsonSerializer.Deserialize<DrinkConfig>(jsonString);
        }
    }
}