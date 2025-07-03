using MarsRover.Services;
using FluentAssertions;
using MarsRover.Models;
using MarsRover.Constants;

namespace MarsRover.Tests.Tests
{
    [TestClass]
    public sealed class RoverInstructionUtilityTests
    {
        [TestMethod]
        public void RoverInstructionUtility_ProcessInstruction_MoveForward()
        {
            var marsGrid = MarsGridUtilities.GenerateMarsGrid(2, 2);
            var rover = new Rover
            {
                FacingDirection = Enums.CardinalDirectionsEnum.N,
                CurrentLocation = marsGrid[0, 0]
            };

            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.MOVE_FORWARD);

            rover.CurrentLocation.Should().Be(marsGrid[0, 1]);
        }

        [TestMethod]
        public void RoverInstructionUtility_ProcessInstruction_MoveOffTheMap()
        {
            var marsGrid = MarsGridUtilities.GenerateMarsGrid(2, 2);
            var rover = new Rover
            {
                FacingDirection = Enums.CardinalDirectionsEnum.N,
                CurrentLocation = marsGrid[0, 1]
            };

            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.MOVE_FORWARD);

            rover.CurrentLocation.Should().Be(marsGrid[0, 1]);
            rover.IsLost.Should().BeTrue();
        }

        [TestMethod]
        public void RoverInstructionUtility_ProcessInstruction_CanNotMoveOffTheMap()
        {
            var marsGrid = MarsGridUtilities.GenerateMarsGrid(2, 2);
            marsGrid[0, 1].HasScent = true;

            var rover = new Rover
            {
                FacingDirection = Enums.CardinalDirectionsEnum.N,
                CurrentLocation = marsGrid[0, 1]
            };

            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.MOVE_FORWARD);

            rover.CurrentLocation.Should().Be(marsGrid[0, 1]);
            rover.IsLost.Should().BeFalse();
        }

        [TestMethod]
        public void RoverInstructionUtility_ProcessInstruction_RotateRightFromNorth()
        {
            var marsGrid = MarsGridUtilities.GenerateMarsGrid(2, 2);
            var rover = new Rover
            {
                FacingDirection = Enums.CardinalDirectionsEnum.N,
                CurrentLocation = marsGrid[0, 1]
            };

            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.ROTATE_RIGHT);
            rover.FacingDirection.Should().Be(Enums.CardinalDirectionsEnum.E);
            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.ROTATE_RIGHT);
            rover.FacingDirection.Should().Be(Enums.CardinalDirectionsEnum.S);
            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.ROTATE_RIGHT);
            rover.FacingDirection.Should().Be(Enums.CardinalDirectionsEnum.W);
            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.ROTATE_RIGHT);
            rover.FacingDirection.Should().Be(Enums.CardinalDirectionsEnum.N);
        }

        [TestMethod]
        public void RoverInstructionUtility_ProcessInstruction_RotateLeftFromNorth()
        {
            var marsGrid = MarsGridUtilities.GenerateMarsGrid(2, 2);
            var rover = new Rover
            {
                FacingDirection = Enums.CardinalDirectionsEnum.N,
                CurrentLocation = marsGrid[0, 1]
            };

            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.ROTATE_LEFT);
            rover.FacingDirection.Should().Be(Enums.CardinalDirectionsEnum.W);
            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.ROTATE_LEFT);
            rover.FacingDirection.Should().Be(Enums.CardinalDirectionsEnum.S);
            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.ROTATE_LEFT);
            rover.FacingDirection.Should().Be(Enums.CardinalDirectionsEnum.E);
            RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, InstructionConstants.ROTATE_LEFT);
            rover.FacingDirection.Should().Be(Enums.CardinalDirectionsEnum.N);
        }
    }
}
