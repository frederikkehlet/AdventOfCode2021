string inputFilePath = @"D:\PersonalProjects\AdventOfCode2021\Day02\input.txt";
string[] commands = System.IO.File.ReadAllLines(inputFilePath);

// part 1
int horizontal = 0;
int depth = 0;

foreach (string command in commands) 
{
    string direction = command.Split(" ")[0];
    int value = Convert.ToInt32(command.Split(" ")[1]);

    switch (direction) 
    {
        case "forward":
            horizontal += value;
            break;
        case "up":
            depth -= value;
            break;
        case "down":
            depth += value;
            break;
        default:
            break;
    }
}

Console.WriteLine($"Part 1 answer: {horizontal * depth}");

// part 2
horizontal = 0;
depth = 0;
int aim = 0;

foreach (string command in commands) 
{
    string direction = command.Split(" ")[0];
    int value = Convert.ToInt32(command.Split(" ")[1]);

    switch (direction) 
    {
        case "forward":
            horizontal += value;
            depth += aim * value;
            break;
        case "up":
            aim -= value;
            break;
        case "down":
            aim += value;
            break;
        default:
            break;
    }
}

Console.WriteLine($"Part 2 answer: {horizontal * depth}");