using MARS.Business.Models;
using MARS.Core;
using MARS.Core.Interfaces;
using MARS.Core.States;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MARS.Tests
{
    [TestClass]
    public class GenericHandlerTests
    {
        [TestCategory("GenericHandler Tests")]
        [TestMethod]
        public void WhenRoversAreMovedIn2DCartesianSuccessfully()
        {
            var rover = new Rover { Id = "MARS_001", Name = "First Rover" };
            var handler = new GenericHandler<Rover>(new D3Coordinate(5, 5, 0), new D3Coordinate(1, 2, 0), rover, new North3DState())
                .TurnLeft() // L
                .Move() // M
                .TurnLeft() // L
                .Move() // M
                .TurnLeft() // L
                .Move() // M
                .TurnLeft() // L
                .Move() // M
                .Move(); // M

            var message = handler.GetStatusMessage();
        }

        [TestCategory("GenericHandler Tests")]
        [TestMethod]
        public void WhenRoversAreMovedIn3DCartesianSuccessfully()
        {
            //
            // Arrange
            //
            var rover = new Rover { Id = "MARS_001", Name = "First Rover" };
            //
            // Act
            //
            var handler = new GenericHandler<Rover>(new D3Coordinate(5, 5, 5), new D3Coordinate(0, 0, 0), rover, new North3DState())
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