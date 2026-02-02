using Microsoft.Extensions.Configuration;
using RobotSpiders.Application;
using RobotSpiders.Application.Input;
using RobotSpiders.Application.Logging;
using RobotSpiders.Domain;
using RobotSpiders.Infrastructure.Logging;

/// <summary>
/// Console boundary:
/// - Reads strict input
/// - Wires dependencies 
/// - Executes command pipeline
/// - Writes strict output
/// </summary>
public static class Program
{
    public static int Main()
    {
        ILogger logger = new NullLogger();

        try
        {            
            // Strict input contract
            var wallInput = Console.ReadLine();
            var spiderInput = Console.ReadLine();
            var instructions = Console.ReadLine();

            if (wallInput is null || spiderInput is null || instructions is null)
            {
                throw new ArgumentException("Input Can't be null");
            }
                

            var wallDimensions = wallInput.Split(' ', StringSplitOptions.TrimEntries);
            var spiderPosition = spiderInput.Split(' ', StringSplitOptions.TrimEntries);

            // Parse wall
            var wall = new Wall(
                InputValueParser.ParseRequiredInt(wallDimensions.ElementAtOrDefault(0), "Wall Width"),
                InputValueParser.ParseRequiredInt(wallDimensions.ElementAtOrDefault(1), "Wall Height")
            );

            // Parse direction (required)
            var directionText = spiderPosition.ElementAtOrDefault(2)
                ?? throw new ArgumentException("Spider direction is required");

            if (!Enum.TryParse<Direction>(directionText, true, out var direction))
                throw new ArgumentException($"Invalid direction: '{directionText}'");

            // Parse position
            var position = new Position(
                InputValueParser.ParseRequiredInt(spiderPosition.ElementAtOrDefault(0), "Spider X"),
                InputValueParser.ParseRequiredInt(spiderPosition.ElementAtOrDefault(1), "Spider Y")
            );

            if (!wall.IsInside(position))
                throw new InvalidOperationException(
                    $"Spider position {position} is outside the wall");

          
            var spider = new Spider(position,direction,wall);

            // Load config (cross-cutting only)
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true)
                .Build();

            var logOptions =
                config.GetSection("Logging").Get<LoggingOptions>()
                ?? new LoggingOptions();

            logger = logOptions.Enabled
                ? new FileLogger(logOptions.FilePath)
                : new NullLogger();


            // Application pipeline
            var factory = new CommandFactory(spider, logger);
            var processor = new CommandProcessor(factory);

            processor.Execute(instructions);

            // Strict output contract
            Console.WriteLine($"{spider.Position.X} {spider.Position.Y} {spider.Direction}");
            return 0;
        }
        catch (Exception ex)
        {
            // Unified exception logging
            logger.Log($"Fatal error: {ex}");
            BootstrapLogger.Log(ex);
            return 1;
        }
    }
}