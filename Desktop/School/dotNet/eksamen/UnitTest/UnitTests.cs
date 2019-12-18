using System;
using System.Collections.Generic;
using System.Linq;
using CarRadar;
using CarRadar.Controllers;
using CarRadar.Models;
using CarRadar.Data;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace UnitTest
{
    
    public class UnitTests
    {
         
        [Fact]
        public void TestSwap()
        {
            var carRepository = new CarsRepository();
            var car = new Car() { Brand = "Fiat", Model = "Punto" };
            car = carRepository.SwapBrandAndModel(car);
            Assert.Equal("Fiat", car.Model);
            Assert.Equal("Punto", car.Brand);
        }
    }
}
