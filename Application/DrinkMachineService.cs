using Domain;
using Microsoft.Extensions.Logging;


namespace Application
{
    public class DrinkMachineService : IDrinkMachineService
    {
        private readonly IDrinksRepository _drinkRepository;
        private readonly ILogger<DrinkMachineService> _logger;
        public DrinkMachineService(IDrinksRepository drinkRepository, ILogger<DrinkMachineService> logger)
        {
            _drinkRepository = drinkRepository;
            _logger = logger;
        }

        public IEnumerable<Drink> GetAllDrinks()
        {
            return _drinkRepository.GetAllDrinks();
        }

        public Drink GetDrinkByName(string drinkName)
        {
            return _drinkRepository.GetDrinkByName(drinkName);
        }

        public DrinkResult MakeDrink(Drink drinkRequest)
        {
            // Your logic here to make the drink based on the request
            // This might involve handling the ingredients and their properties

            IDrinkBuilder drinkBuilder = new DrinkBuilder(_logger);

            drinkBuilder.SetDrink(drinkRequest);
            drinkBuilder.MakeDrink();

            // Return result indicating success or failure with a message
            return new DrinkResult { Success = true, Message = "Drink successfully made!" };
        }
    }

    public interface IDrinkMachineService
    {
        IEnumerable<Drink> GetAllDrinks();
        Drink GetDrinkByName(string drinkName);
        DrinkResult MakeDrink(Drink drinkRequest);
    }
}
