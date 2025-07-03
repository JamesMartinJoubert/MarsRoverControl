using MarsRover.Models;

namespace MarsRover.Services
{
    public static class MarsGridUtilities
    {
        public static bool AreGridSizesValid(int gridWidth, int gridHeight)
        {
            return gridWidth > 0 && gridHeight > 0;
        }

        public static MarsGridCell[,] GenerateMarsGrid(int gridWidth, int gridHeight)
        {
            var marsGrid = new MarsGridCell[gridWidth, gridHeight];

            for (int currentWidthIndex = 0; currentWidthIndex < gridWidth; currentWidthIndex++)
            {
                for (int currentHeightIndex = 0; currentHeightIndex < gridHeight; currentHeightIndex++)
                {
                    marsGrid[currentWidthIndex, currentHeightIndex] = new MarsGridCell
                    {
                        Latitude = currentWidthIndex,
                        Longitude = currentHeightIndex
                    };
                }
            }

            return marsGrid;
        }
    }
}