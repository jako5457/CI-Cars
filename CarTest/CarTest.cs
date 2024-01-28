using CarLibrary;

namespace CarTest
{
    public class CarTest
    {
        [Fact]
        public void GetAmountOfCars()
        {
            int ExpectedCars = 4;

            //Arrange
            CarService carService = new CarService();

            //Act
            int Cars = carService.GetCars().Count();

            //Assert
            Assert.Equal(ExpectedCars, Cars);
        }

        [Fact]
        public void GetCarById() {

            int ExpectedCarId = 1;

            //Arrange
            CarService carService = new CarService();

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
            CarService carService = new CarService();

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
            CarService carService = new CarService();

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
            int ExpectedAmountOfCars = Amount + 4;

            //Arrange
            CarService carService = new CarService();

            //Act
            for (int i = 0; i < Amount; i++) 
            {
                carService.AddCar("Car", "Type");
            }

            int CreatedCars = carService.GetCars().Count();
            
            //Assert
            Assert.Equal(ExpectedAmountOfCars, CreatedCars);
        }
    }
}