using MarsRover.Models;
using MarsRover.Enums;

namespace MarsRover.Models
{
    public class Rover
    {
        public CardinalDirectionsEnum FacingDirection { get; set; }
        public MarsGridCell CurrentLocation { get; set; }
        public char[] CurrentInstructions { get; set; }
        public bool IsLost { get; set; }
    }
}
