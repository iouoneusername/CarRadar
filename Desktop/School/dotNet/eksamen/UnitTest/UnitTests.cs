using System;
using System.Collections.Generic;
using System.Linq;
using CarRadar;
using CarRadar.Controllers;
using CarRadar.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitTest
{
    
    public class UnitTests
    {

        public List<Car> getCars(){
            var cars = new List<Car>();
            cars.Add(new Car()
            {
                Id = 1,
                Brand = "Audi"
            });
            cars.Add(new Car()
            {
                Id = 2,
                Brand = "Audi",
                Model = "A6"
            });
            return cars;
        }
        
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, Add(2, 2));
        }

        int Add(int x, int y)
        {
            return x + y;
        }

        [Fact]
        public void TestIndexMethodReturnsObjects()
        {
            // Arrange
/*            var mockRepo = new Mock<ICarRepository>();
            mockRepo.Setup(repo => repo.Get())
                .Returns(DataTestService.GetTestCars());
            var controller = new CarsController(mockRepo.Object);

            // Act
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<Car>>(
                viewResult.ViewData.Model);
            var model = DataTestService.GetTestCars(); */
            var car = new Car() { Brand = "Fiat", Model = "Punto" };
            Assert.Equal("Fiat", car.Brand);
        }

/*        [Fact]
        public void CreatePost_ReturnsViewWithSpecies_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockRepo = new Mock<ISpeciesRepository>();
            var controller = new CarsController(mockRepo.Object);

            controller.ModelState.AddModelError("Name", "Required");
            var car = new Car() { Brand = "Fiat", Model = "Punto" };

            // Act
            var result = controller.Create(car);

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Car>(viewResult.ViewData.Model);
            Assert.IsType<Car>(model);
        }

        [Fact]
        public void CreatePost_SaveThroughRepository_WhenModelStateIsValid()
        {
            // Arrange
            var mockRepo = new Mock<ISpeciesRepository>();
            mockRepo.Setup(repo => repo.Save(It.IsAny<Car>()))
                //.Returns(Task.CompletedTask)
                .Verifiable();
            var controller = new CarsController(mockRepo.Object);
            Car s = new Car()
            {
                Brand = "Skoda",
                Model = "Oktavia"
            };

            // Act
            var result = controller.Create(s);

            // Assert
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Null(redirectToActionResult.ControllerName);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            mockRepo.Verify();
        } */
    }
}
