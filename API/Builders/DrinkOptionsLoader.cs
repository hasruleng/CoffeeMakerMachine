using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Domain;

namespace CoffeeDrinksBuilderApp.Builders
{
    public interface IDrinkOptionsLoader {
        public DrinksRepository LoadFrom(string Someparam);
    }
    
    //concrete implementation that reads JSON file
    public class ConfigFile_DrinkOptionsLoader : IDrinkOptionsLoader
    {
        public DrinksRepository LoadFrom(string configFile)
        {
            string jsonString = File.ReadAllText(configFile);
            return JsonSerializer.Deserialize<DrinksRepository>(jsonString);
        }
    }
}