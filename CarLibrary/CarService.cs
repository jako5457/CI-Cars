using CarLibrary.Entities;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace CarLibrary
{
    public class CarService : ICarService
    {
        private readonly CarDbContext context;

        public CarService(CarDbContext context)
        {
            this.context = context;
        }

        public List<Car> GetCars() => context.Cars.ToList();

        public Car? GetCarById(int id) => context.Cars.FirstOrDefault(x => x.Id == id);

        public void AddCar(string name, string type)
        {
            context.Cars.Add(new Car { Name = name, Type = type });
            context.SaveChanges();
        }

        public void RemoveCar(int id)
        {
            var car = context.Cars.FirstOrDefault(x => x.Id == id);

            if (car != null)
                context.Cars.Remove(car);
            context.SaveChanges();
        }
    }
}
