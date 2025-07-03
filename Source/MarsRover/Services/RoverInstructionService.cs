using MarsRover.Constants;
using MarsRover.Enums;
using MarsRover.Models;

namespace MarsRover.Services
{
    public static class RoverInstructionService
    {
        public static void ProcessRoverInstruction(MarsGridCell[,] marsGrid, Rover rover, char instruction)
        {
            switch (instruction)
            {
                case InstructionConstants.ROTATE_LEFT:
                    RotateRover(rover, instruction);
                    break;
                case InstructionConstants.ROTATE_RIGHT:
                    RotateRover(rover, instruction);
                    break;
                case InstructionConstants.MOVE_FORWARD:
                    MoveRoverForward(marsGrid, rover);
                    break;
            }
        }

        private static void RotateRover(Rover rover, char rotationCommand)
        {
            var newFacingDirection = ProcessRotationCommand(rover.FacingDirection, rotationCommand);

            if (newFacingDirection == CardinalDirectionsEnum.Invalid)
            {
                return;
            }

            rover.FacingDirection = newFacingDirection;
        }

        private static CardinalDirectionsEnum ProcessRotationCommand(CardinalDirectionsEnum currentRotation, char rotationCommand)
        {
            switch (currentRotation)
            {
                case CardinalDirectionsEnum.N:
                    return rotationCommand == InstructionConstants.ROTATE_LEFT ? CardinalDirectionsEnum.W : CardinalDirectionsEnum.E;
                case CardinalDirectionsEnum.S:
                    return rotationCommand == InstructionConstants.ROTATE_LEFT ? CardinalDirectionsEnum.E : CardinalDirectionsEnum.W;
                case CardinalDirectionsEnum.E:
                    return rotationCommand == InstructionConstants.ROTATE_LEFT ? CardinalDirectionsEnum.N : CardinalDirectionsEnum.S;
                case CardinalDirectionsEnum.W:
                    return rotationCommand == InstructionConstants.ROTATE_LEFT ? CardinalDirectionsEnum.S : CardinalDirectionsEnum.N;
                default:
                    return CardinalDirectionsEnum.Invalid;
            }
        }

        private static void MoveRoverForward(MarsGridCell[,] marsGrid, Rover rover)
        {
            var newLatitude = rover.CurrentLocation.Latitude;
            var newLongitude = rover.CurrentLocation.Longitude;

            switch (rover.FacingDirection)
            {
                case CardinalDirectionsEnum.N:
                    newLongitude++;
                    break;
                case CardinalDirectionsEnum.S:
                    newLongitude--;
                    break;
                case CardinalDirectionsEnum.E:
                    newLatitude++;
                    break;
                case CardinalDirectionsEnum.W:
                    newLatitude--;
                    break;
            }

            if (!marsGrid.RoverCanMoveHere(newLatitude, newLongitude))
            {
                if (rover.CurrentLocation.HasScent)
                {
                    return;
                }
                rover.CurrentLocation.HasScent = true;
                rover.IsLost = true;
                return;
            }

            rover.CurrentLocation = marsGrid[newLatitude, newLongitude];
        }

        private static bool RoverCanMoveHere(this MarsGridCell[,] marsGrid, int latitude, int longitude)
        {
            if (latitude < 0 || latitude >= marsGrid.GetLength(0) || longitude < 0 || longitude >= marsGrid.GetLength(1))
            {
                return false;
            }

            return true;
        }
    }
}
