using CarLibrary.Dto;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace CarLibrary
{
    public class CarService
    {

        private int count = 0;
        private List<Car> cars;

        public CarService() 
        {
            cars = new List<Car>() {
                new Car { Id = 1, Name = "Tesla Roadster", Type = "EV"}
                , new Car { Id = 2, Name = "Fiat 500", Type = "Gas"}
                , new Car { Id = 3, Name = "Folksvargen Polo", Type = "Diesel"}
                , new Car { Id = 4, Name = "Tesla Cybertruck", Type = "EV"}
            };

            count = 4;
        }

        public List<Car> GetCars() => cars;

        public Car? GetCarById(int id) => cars.FirstOrDefault(x => x.Id == id);

        public void AddCar(string name,string  type)
        {
            count++;

            cars.Add(new Car {  Id = count, Name = name, Type = type });
        }

        public void RemoveCar(int id)
        {
            var car = cars.FirstOrDefault(x => x.Id == id);

            if (car != null)
            cars.Remove(car);
        }
    }
}
