using MarsRover.Services;
using FluentAssertions;

namespace MarsRover.Tests.Tests
{
    [TestClass]
    public sealed class RoverServiceTests
    {
        [TestMethod]
        public void RoverService_CreateRover()
        {
            var marsGrid = MarsGridUtilities.GenerateMarsGrid(2, 2);

            var fileContent = new string[]
            {
                "2 2",
                "0 0 E",
                "FLFLFLF"
            };

            var rover = RoverService.CreateRover(marsGrid, fileContent, 1);

            rover.CurrentLocation.Should().Be(marsGrid[0,0]);
        }

        [TestMethod]
        public void RoverService_MovesInACircleBackToStartingPosition()
        {
            var marsGrid = MarsGridUtilities.GenerateMarsGrid(2, 2);

            var fileContent = new string[]
            {
                "2 2",
                "0 0 E",
                "FLFLFLF"
            };

            var rover = RoverService.CreateRover(marsGrid, fileContent, 1);

            var roverOutput = RoverService.ProcessRover(marsGrid, rover);

            roverOutput.Should().Be($"0 0 S");
        }

        [TestMethod]
        public void RoverService_MovesAndLeavesTheMap()
        {
            var marsGrid = MarsGridUtilities.GenerateMarsGrid(2, 2);

            var fileContent = new string[]
            {
                "2 2",
                "0 0 E",
                "FF"
            };

            var rover = RoverService.CreateRover(marsGrid, fileContent, 1);

            var roverOutput = RoverService.ProcessRover(marsGrid, rover);

            roverOutput.Should().Be($"1 0 E LOST");
        }
    }
}
