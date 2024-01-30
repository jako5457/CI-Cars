using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace CarTest
{
    public class PageTest
    {

        public static string Address = "https://localhost:7289/";

        public static List<Object[]> WebDrivers { get => new List<object[]>
        {
            new object[] { () => new EdgeDriver() },
            new object[] { () => new FirefoxDriver() },
            new object[] { () => new ChromeDriver() }
        };}


        [Theory]
        [MemberData(nameof(WebDrivers))]
        public void TestPageLoad(Func<IWebDriver> Setup)
        {
            //Arrange
            string ExpectedTitle = "Cars";
            IWebDriver webDriver = Setup();

            //Act
            webDriver.Navigate().GoToUrl(Address);

            //Assert
            Assert.Equal(ExpectedTitle, webDriver.Title);
            webDriver.Close();
        }

        [Theory]
        [MemberData(nameof(WebDrivers))]
        public void TestCreateCar(Func<IWebDriver> Setup)
        {
            //Arrange
            IWebDriver webDriver = Setup();

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
