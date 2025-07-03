using MarsRover.Utilities;

var gridWidthInput = 5;
var gridHeightInput = 5;

var areGridSizesValid = MarsGridUtilities.AreGridSizesValid(gridWidthInput, gridHeightInput);

if (!areGridSizesValid)
{
    Console.WriteLine($"Grid sizes Width ({gridWidthInput}) and Height ({gridHeightInput}) are invalid.\nPlease make sure the width and height at at least 1 each.");
}

var marsGrid = MarsGridUtilities.GenerateMarsGrid(gridWidthInput, gridHeightInput);

Console.WriteLine($"Successfully generated a {gridWidthInput}x{gridHeightInput} grid, making a total of {marsGrid.Count} cells.");