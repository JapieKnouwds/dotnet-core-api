using Models;
using Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class PizzaController : ControllerBase
{
    private readonly IPizzaService _pizzaService;
    public PizzaController(IPizzaService pizzaService)
    {
        _pizzaService = pizzaService;
    }

    [HttpGet]
    public ActionResult<List<Pizza>> GetAll() =>
        _pizzaService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Pizza> Get(int id) =>
        _pizzaService.Get(id);        

    [HttpPost]
    public IActionResult Create(Pizza pizza)
    {
        _pizzaService.Create(pizza);
        return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Pizza pizza)
    {
        if (id != pizza.Id)
            return BadRequest();

        var existingPizza = _pizzaService.Get(id);
        if (existingPizza is null)
            return NotFound();

        _pizzaService.Update(pizza);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var pizza = _pizzaService.Get(id);

        if (pizza is null)
            return NotFound();

        _pizzaService.Delete(id);

        return NoContent();
    }
}