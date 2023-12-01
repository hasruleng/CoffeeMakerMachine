using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application;

namespace API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class DrinkMachineController : BaseApiController
    {
        //1: GET showing the list of drinks
        //2: GET choosing one of the drink from the list => its ingredients and adjustability
        //3: POST drink object with the list of ingredients and their properties and make the drink
       private readonly IDrinkMachineService _drinkMachineService;

        public DrinkMachineController(IDrinkMachineService drinkMachineService)
        {
            _drinkMachineService = drinkMachineService;
        }

        [HttpGet]
        public IActionResult GetAllDrinks()
        {
            var drinks = _drinkMachineService.GetAllDrinks();
            return Ok(drinks);
        }

        [HttpGet("{drinkName}")]
        public IActionResult GetDrinkByName(string drinkName)
        {
            var drink = _drinkMachineService.GetDrinkByName(drinkName);

            if (drink == null)
            {
                return NotFound();
            }

            return Ok(drink);
        }

        [HttpPost]
        public IActionResult MakeDrink([FromBody] Drink drinkRequest)
        {
            var result = _drinkMachineService.MakeDrink(drinkRequest);

            if (result.Success)
            {
                return Ok(result.Message);
            }

            return BadRequest(result.Message);
        }
    }
}