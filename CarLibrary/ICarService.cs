using CarLibrary.Entities;

namespace CarLibrary
{
    public interface ICarService
    {
        void AddCar(string name, string type);
        Car? GetCarById(int id);
        List<Car> GetCars();
        void RemoveCar(int id);
    }
}