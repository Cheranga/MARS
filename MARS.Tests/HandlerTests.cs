using System;
using MARS.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MARS.Business.Models;
using MARS.Core;

namespace MARS.Tests
{
    //
    // TODO: Write more tests to cover conditional logic, and functionality
    //
    [TestClass]
    public class HandlerTests
    {
        private const string Category = "Handler";

        [TestCategory(Category)]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void IfInvalidBoundsAreGivenItMustFail()
        {
            //
            // Arrange, act, assert
            //
            var handler = new Handler<Rover>(0, -1);
        }

        [TestCategory(Category)]
        [TestMethod]
        public void WhenItemIsInLowestLeftFacingWestItCannotMove()
        {
            //
            // Arrange
            //
            var handler = new Handler<Rover>(5, 5);
            var rover = new Rover {Id = "1", Name = "A"};
            //
            // Act
            //
            handler.StartIn(rover, 0, 0, Direction.W)
                .Move();

            var message = handler.GetStatusMessage();
            //
            // Assert
            //
            Assert.AreEqual("[1 :: A] in [0, 0] facing [W]", message, "The expected message and the actual message are not the same");
        }

        //
        // TODO: Add more tests for bounds
        //
        [TestCategory(Category)]
        [TestMethod]
        public void WhenItemIsInLowestLeftFacingSouthItCannotMove()
        {
            //
            // Arrange
            //
            var handler = new Handler<Rover>(5, 5);
            var rover = new Rover {Id = "1", Name = "A"};
            //
            // Act
            //
            handler.StartIn(rover, 0, 0, Direction.S)
                .Move();

            var message = handler.GetStatusMessage();
            //
            // Assert
            //
            Assert.AreEqual("[1 :: A] in [0, 0] facing [S]", message, "The expected message and the actual message are not the same");
        }


        [TestCategory(Category)]
        [TestMethod]
        public void ValidInputsMustBeAbleToNavigateRoverSuccessfully()
        {
            //
            // Arrange
            var roverToMars = new Rover { Id = "MARS_001", Name = "First Rover" };
            var roverToSaturn = new Rover { Id = "MARS_002", Name = "Second Rover" };
            //
            // Act
            //
            var firstRoverStatus = new Handler<Rover>(5, 5).StartIn(roverToMars, 1, 2, Direction.N)
                .TurnLeft() // L
                .Move() // M
                .TurnLeft() // L
                .Move() // M
                .TurnLeft() // L
                .Move() // M
                .TurnLeft() // L
                .Move() // M
                .Move() // M
                .GetStatusMessage();

            var secondRoverStatus = new Handler<Rover>(5, 5).StartIn(roverToSaturn, 3, 3, Direction.E)
                .Move() // M
                .Move() // M
                .TurnRight() // R
                .Move() // M
                .Move() // M
                .TurnRight() // R
                .Move() // M
                .TurnRight() // R
                .TurnRight() // R
                .Move() // M
                .GetStatusMessage();

            Assert.AreEqual("[MARS_001 :: First Rover] in [1, 3] facing [N]", firstRoverStatus, "The expected message and the actual message are not the same");
            Assert.AreEqual("[MARS_002 :: Second Rover] in [5, 1] facing [E]", secondRoverStatus, "The expected message and the actual message are not the same");
        }
    }
}
