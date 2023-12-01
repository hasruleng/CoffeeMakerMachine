#pragma warning disable CS8618 // Non-nullable property is uninitialized. Consider declaring as nullable.
#pragma warning disable CS8602 // Dereference of a possibly null reference.

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Drink
    {
        public string Name { get; set; }
        public List<IngredientConfig> Ingredients { get; set; }

        public bool Adjustable { get; set; } = false;

        // Other properties specific to a drink
    }

    public class IngredientConfig
    {
        public string Name { get; set; }
        public int Quantity { get; set; } // Represents the ingredient's quantity for machine
        public int HotWaterVolume { get; set; } = 0; //0, 1, 2, 3, 4, 5 times by 40 ml. If set bigger than 0, Hot water is mixed with the ingredient 
        public int HotWaterTemp { get; set; } = 88; //Celcius
        public bool AdjustableStrength { get; set; } = false; // Strength means quantity of the ingredient in the machine
        
        [Range(0, 5, ErrorMessage = "The value must be between 0 and 5.")]
        public int DefaultStrength { get; set; } = 1; // the Default Strength level represent the number of specified in quantity property
    }

}

#pragma warning restore CS8618
#pragma warning restore CS8602