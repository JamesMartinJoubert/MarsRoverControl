# Mars Rover Control
A small console project where you instruct mars rovers to move on a grid map representing the surface or mars.

## Project Setup
Tools
- Git
- Tortoise Git
- Visual Studio 2022 (VS2022)
- .NET9

### Instructions
- Please ensure you have Visual Studio 2022 installed with the latest version of .NET9.
- Clone down the repository to your work station.
- In the root directory double click the MarsRover.sln file to open the project in VS2022.
- Click the Run button at the top of VS2022 to execute the project.

### Unit Tests
You can run the unit tests of this application inside of VS2022 by going to (Test -> Run All Tests) in the utility bar at the top of the screen.

### How Does It Work?
The application reads a set of instructions from a SampleData.txt file.
The file contains instructions pertaining to the size of the mars grid that needs to be created, starting positions and rotations for each rover, along with a set of instructions for each of them.
Each rover's instructions are processed sequentially, one after the other.

The first line in the SampleData.txt file is two numbers separated by a space.

The first number is the largest index on the width/latitude of the grid.

The second number is the largest index on the height/longitude of the grid.

```
5 5
```

Each rover has their own instructions that start from the second line of the sample data file, each made up of two lines.

The first line contains the latitude and longitude of the location where the rover will start moving from, along with the direction it is facing at the start.

The second line contains a list of instructions, each character being a single instruction.

L = Turn Left / Rotate Anti-Clockwise
R = Turn Right / Rotate Clockwise
F = Move Forward in the direction the rover is facing

```
0 2 E
FLRF

1 1 N
FFF
```

Should a rover ever leave the space of the grid, it will be lost and all instructions will cease at that point.

But a rover that is lose leaves a scent behind, that signals other rovers of danger, allowing them to ignore an instruction that would cause them to be lost on that same cell, all other instructions will continue to run after the ignored instruction.

After each rover has executed all of its instruction, or is no longer able to execute instructions, its last known location and direction it was facing will be printed out on the console, along with a flag if that rover was lost.

```
0 1 N
2 2 E LOST
```

### Replacing Sample Data
The project reads from the SampleData.txt file under the Data folder of the MarsRover project.
The easiest solution would be to replace the content of this text file with your own data set.
You can also replace and overwrite the file with your own, if they share the same name.

If you want to add your own file with a different name, then you need to add the text file from inside of VS2022 into the Data folder.
Make sure you mark the file as Copy Always under the files properties in VS2022 otherwise the application won't find the file during run time.
Lastly remember to update the file name you want to read from in the Program.cs class.

## Assumption Made
- The rover starting position and rotation will always be valid
- There are spaces between the coordinates and directions when it comes to rover start locations and grid size. e.g. `0 0 E` `5 5 W`
- There will also be blank line between each rover's set of instructions
- No validation was required on grid size, and rover instruction lengths
- Invalid instructions will be ignored

## Next Steps
- I am able to expand on the types of commands the rover can under take by expanding on the switch statement in the ProcessInstruction method.
- A visual display of the rover navigating the grid would also be a nice addition

## Notes
The application was made simple and easy to understand.

Majority of the classes were made static, as the processes are very simple input/output methods.

There was no need for overly complicated services that need to be injected, and no need for any data persistance to store results.

This is however something that can be added if an application like this had to grow into a product.
