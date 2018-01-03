using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MARS.Business;
using MARS.Business.Models;
using MARS.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MARS.Tests
{
    [TestClass]
    public class D3HandlerTests
    {
        [TestCategory("D3HandlerTests")]
        [TestMethod]
        public void ValidInputsMustBeAbleToNavigateRoverSuccessfully()
        {
            //
            // Arrange
            //
            var roverToMars = new Rover { Id = "MARS_001", Name = "First Rover" };
            //
            // Act
            //
            var handler = new D3Handler<Rover>(5, 5, 5).StartIn(roverToMars, 0, 0, 0, Direction.N)
                .TurnUp()
                .Move()
                .TurnRight()
                .Move()
                .TurnLeft()
                .Move()
                .TurnUp()
                .Move()
                .Move();
            //
            // Assert
            //
            var message = handler.GetStatusMessage();
        }
    }
}
