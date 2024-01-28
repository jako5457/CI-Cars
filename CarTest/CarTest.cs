using CarLibrary;
using Microsoft.EntityFrameworkCore;

namespace CarTest
{
    public class CarTest
    {

        [Fact]
        public void GetAmountOfCars()
        {
            int ExpectedCars = 4;

            //Arrange
            using CarDbContext dbContext = TestMethods.CreateDbContext<CarDbContext>();
            CarService carService = new CarService(dbContext);

            //Act
            int Cars = carService.GetCars().Count();

            //Assert
            Assert.Equal(ExpectedCars, Cars);
        }

        [Fact]
        public void GetCarById() {

            int ExpectedCarId = 1;

            //Arrange
            using CarDbContext dbContext = TestMethods.CreateDbContext<CarDbContext>();
            CarService carService = new CarService(dbContext);

            //Act
            var car = carService.GetCarById(ExpectedCarId);

            //Assert
            Assert.NotNull(car);
            Assert.Equal(ExpectedCarId, car.Id);
        }

        [Fact]
        public void CreateCarCheckId() 
        {
            int ExpectedCreatedCarId = 5;

            //Arrange
            using CarDbContext dbContext = TestMethods.CreateDbContext<CarDbContext>();
            CarService carService = new CarService(dbContext);

            //Act
            carService.AddCar("Ferrari", "Gas");

            //Assert
            var car = carService.GetCarById(ExpectedCreatedCarId);

            Assert.NotNull(car);
            Assert.Equal(ExpectedCreatedCarId, car.Id);
        }

        [Fact]
        public void RemoveCarCheckCount() 
        {
            int ExpectedCarCount = 3;

            //Arrange
            using CarDbContext dbContext = TestMethods.CreateDbContext<CarDbContext>();
            CarService carService = new CarService(dbContext);

            //Act
            carService.RemoveCar(4);

            //Assert
            int ActualCarCount = carService.GetCars().Count();

            Assert.Equal(ExpectedCarCount, ActualCarCount);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(50)]
        [InlineData(100)]
        [InlineData(500)]
        [InlineData(1000)]
        public void CreateAlotOfCars(int Amount)
        {
            //Arrange
            int ExpectedAmountOfCars = Amount + 4;

            string ConnectionString = "Cardb" + Random.Shared.Next(0, 10000);

            //Act
            for (int i = 0; i < Amount; i++) 
            {
                using CarDbContext dbContext = TestMethods.CreateDbContext<CarDbContext>(ConnectionString,true);
                CarService carService = new CarService(dbContext);

                carService.AddCar("Car", "Type");
            }

            using CarDbContext Context = TestMethods.CreateDbContext<CarDbContext>(ConnectionString, true);
            CarService Service = new CarService(Context);

            int CreatedCars = Service.GetCars().Count();
            
            //Assert
            Assert.Equal(ExpectedAmountOfCars, CreatedCars);
        }
    }
}