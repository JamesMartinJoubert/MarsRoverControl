using MarsRover.Services;

var currentDirectory = Directory.GetCurrentDirectory();
var fileContent = File.ReadAllLines($"{currentDirectory}/Data/SampleData.txt");

var gridSizeLine = fileContent[0].Split(" ");
var gridWidthInput = int.Parse(gridSizeLine[0]) + 1;
var gridHeightInput = int.Parse(gridSizeLine[1]) + 1;

var areGridSizesValid = MarsGridUtilities.AreGridSizesValid(gridWidthInput, gridHeightInput);

if (!areGridSizesValid)
{
    Console.WriteLine($"Grid sizes Width ({gridWidthInput}) and Height ({gridHeightInput}) are invalid.\nPlease make sure the width and height at at least 1 each.");
    return;
}

var marsGrid = MarsGridUtilities.GenerateMarsGrid(gridWidthInput, gridHeightInput);

// Assuming there are always spaces in the sample data that separates the rovers, increasing the index by 3
// If there are no spaces separating the rovers, then increment the index by 2
for (int fileLineIndex = 1; fileLineIndex < fileContent.Length; fileLineIndex += 3)
{
    var rover = RoverService.CreateRover(marsGrid, fileContent, fileLineIndex);
    var roverOutput = RoverService.ProcessRover(marsGrid, rover);
    Console.WriteLine(roverOutput);
}






