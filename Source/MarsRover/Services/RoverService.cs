using MarsRover.Enums;
using MarsRover.Models;

namespace MarsRover.Services
{
    public static class RoverService
    {
        public static Rover CreateRover(MarsGridCell[,] marsGrid, string[] fileContent, int fileLineIndex)
        {
            var roverIdentityLine = fileContent[fileLineIndex];
            var roverInstructionLine = fileContent[fileLineIndex + 1];

            var roverIdentitySplit = roverIdentityLine.Split(" ");
            var roverLatitude = int.Parse(roverIdentitySplit[0]);
            var roverLongitude = int.Parse(roverIdentitySplit[1]);
            var roverFacingDirection = (CardinalDirectionsEnum)Enum.Parse(typeof(CardinalDirectionsEnum), roverIdentitySplit[2]);
            var roverInstructions = roverInstructionLine.ToArray();

            // Assuming rovers will always start in a valid location
            var roverstartingLocation = marsGrid[roverLatitude, roverLongitude];

            var rover = new Rover
            {
                FacingDirection = roverFacingDirection,
                CurrentLocation = roverstartingLocation,
                CurrentInstructions = roverInstructions
            };

            return rover;
        }

        public static string ProcessRover(MarsGridCell[,] marsGrid, Rover rover)
        {
            foreach (var instruction in rover.CurrentInstructions)
            {
                RoverInstructionService.ProcessRoverInstruction(marsGrid, rover, instruction);

                if (rover.IsLost)
                {
                    break;
                }
            }

            var roverPosition = $"{rover.CurrentLocation.Latitude} {rover.CurrentLocation.Longitude} {rover.FacingDirection}";

            if (rover.IsLost)
            {
                roverPosition = $"{roverPosition} LOST";
            }

            return roverPosition;
        }
    }
}
