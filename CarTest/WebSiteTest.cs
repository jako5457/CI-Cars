using CarLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarWebsite.Pages;

namespace CarTest
{
    public class WebSiteTest
    {

        [Fact]
        public void TestGetCars()
        {
            //Arrange
            using CarDbContext dbContext = TestMethods.CreateDbContext<CarDbContext>();
            CarService carService = new CarService(dbContext);

            IndexModel indexModel = new IndexModel(carService, null!);

            //Act
            indexModel.OnGet();

            //assert
            Assert.Equal(4, indexModel.Cars.Count());
        }

    }
}
