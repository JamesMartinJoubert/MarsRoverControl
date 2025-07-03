using MarsRover.Models;

namespace MarsRover.Utilities
{
    public static class MarsGridUtilities
    {
        public static bool AreGridSizesValid(int gridWidth, int gridHeight)
        {
            return gridWidth > 0 && gridHeight > 0;
        }

        public static List<MarsGridCell> GenerateMarsGrid(int gridWidth, int gridHeight)
        {
            var marsGrid = new List<MarsGridCell>();

            for (int currentHeightIndex = 0; currentHeightIndex < gridHeight; currentHeightIndex++)
            {
                for (int currentWidthIndex = 0; currentWidthIndex < gridWidth; currentWidthIndex++)
                {
                    marsGrid.Add(new MarsGridCell
                    {
                        Latitude = currentHeightIndex,
                        Longitude = currentWidthIndex
                    });
                }
            }

            return marsGrid;
        }
    }
}