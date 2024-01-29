using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace CarTest
{
    public class PageTest
    {

        public static string Address = "https://localhost:7289/";

        [Fact]
        public void TestPageLoad()
        {
            //Arrange
            string ExpectedTitle = "Cars";
            IWebDriver webDriver = new EdgeDriver();

            //Act
            webDriver.Navigate().GoToUrl(Address);

            //Assert
            Assert.Equal(ExpectedTitle, webDriver.Title);
            webDriver.Close();
        }

        [Fact]
        public void TestCreateCar()
        {
            //Arrange
            IWebDriver webDriver = new EdgeDriver();

            //Act
            webDriver.Navigate().GoToUrl(Address + "Cars/Create");

            var CarNameBox = webDriver.FindElement(By.Id("CarName"));
            var CarTypeBox = webDriver.FindElement(By.Id("CarType"));

            var SubmitButton = webDriver.FindElement(By.XPath("/html/body/div/main/form/button"));

            CarNameBox.SendKeys("Small Car");
            CarTypeBox.SendKeys("Pedal");

            SubmitButton.Click();

            //Assert
            Assert.Equal(Address, webDriver.Url);
            webDriver.Close();
        }

    }
}
