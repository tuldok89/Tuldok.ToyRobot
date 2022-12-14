# Tuldok.ToyRobot

## How to run the app

### Visual Studio 2022

1. Open the solution file in Visual Studio.
2. Go to the menu bar, then select Debug -> Start without debugging.

### Command-line Interface

1. Open a terminal / command prompt in the `Tuldok.ToyRobot.Cli` directory.
2. Execute `dotnet run` in the terminal.

## How to run unit tests

### Visual Studio

1. Open the solution file in Visual Studio.
2. Go to the menu bar, then select Test -> Run All Tests

### Command-line Interface

1. Open a terminal / command promptin the `Tuldok.ToyRobot.Test` directory.
2. Execute `dotnet test` in the terminal.

## Commands

- `PLACE X,Y,DIRECTION`: Valid values for `X` and `Y` are 0 to 4. `DIRECTION` is one of the for cardinal directions: `NORTH`, `EAST`, `SOUTH` or `WEST`.
- `MOVE`: Instructs the robot to move 1 square in the direction it is facing.
- `LEFT`: Instructs the robot to rotate 90° anticlockwise/counterclockwise.
- `RIGHT`: Instructs the robot to rotate 90° clockwise.
- `REPORT`: Outputs the robot's current location on the tabletop and the direction it is facing.
- `QUIT`: Exits the application.