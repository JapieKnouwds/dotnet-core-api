using Models;

namespace Services 
{
  public interface IPizzaService
  {
      List<Pizza> GetAll();

      Pizza Get(int id);

      void Create(Pizza pizza);

      void Delete(int id);

      void Update(Pizza pizza);
  }
}