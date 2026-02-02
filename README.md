## RobotSpiders

## Overview
A C# console application that controls an autonomous spider navigating a rectangular wall grid based on a sequence of instructions.

The solution emphasises clean architecture, SOLID principles, and testable design without unnecessary complexity.

---

## Problem Summary
- Wall grid from `(0,0)` to `(MaxX, MaxY)`
- Spider starts at a given position and direction
- Instructions:
  - `L` – turn left
  - `R` – turn right
  - `F` – move forward
- Spider remains within boundaries
- Final position and direction are printed

---

## Architecture
The solution follows a layered approach:

- Domain – pure business logic (`Spider`, `Wall`, `Position`)
- Application – command execution and input parsing
- Infrastructure – logging and configuration
- Program – composition root and console boundary

---

## Design Patterns
- Command Pattern – each instruction is represented as a command
- Decorator Pattern – logging is added without modifying behaviour

---

## SOLID Principles

### SRP – each class has a single responsibility
- `Spider` → movement rules and state
- `Wall` → boundary validation
- Command classes → single action execution
- `CommandProcessor` → instruction sequencing
- `CommandFactory` → command creation and decoration
- `InputValueParser` → input validation and parsing
- Logging classes → logging only


### OCP - The system is open for extension but closed for modification
- New commands can be added by implementing `ICommand`
- Execution logic does not change
- Logging is added via decoration, not conditional logic


### LSP – commands and decorators are interchangeable
- All command implementations adhere to the `ICommand` contract
- Decorated commands (LoggingCommandDecorator) can replace any command without affecting behaviour.

### ISP – small, focused interfaces (`ICommand`, `ILogger`)
- ICommand exposes only Execute()
- ILogger exposes only Log(string message)
- Consumers depend only on what they use


### DIP - High-level modules depend on abstractions
– Application code depends on ILogger, not concrete loggers
- Infrastructure provides implementations
- Logging is disabled by injecting NullLogger

SOLID is applied pragmatically, focusing on clarity and maintainability.

---

## Configuration
Logging is configured via `appsettings.json`:

json
{
  "Logging": {
    "Enabled": true,
    "FilePath": "spider.log"
  }
}
Logging is disabled using a NullLogger

---

## Testing

Unit tests for domain logic, commands, parsing, and logging

Component / integration tests for the full command pipeline

---

## Running the Application
dotnet run

Input:
7 15
2 4 Left
FLFLFRFFLF

Output:
3 1 Right

## Running Tests
dotnet test