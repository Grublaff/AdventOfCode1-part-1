namespace AdventOfCode1;
public class Program
{
    private static void Main(string[] args)
    {
        var path = Environment.CurrentDirectory;
        var text = File.ReadAllLines($"{path}/InputData.txt");

        long highestValue = 0;
        const long currentValue = 0;

        highestValue = GetHighestValue(text, currentValue, highestValue);

        Console.WriteLine($"The fattest elf brought {highestValue} cal worth of food");
        Console.ReadLine();
    }

    private static long GetHighestValue(IEnumerable<string> text, long currentValue, long highestValue)
    {
        foreach (var character in text)
        {
            Console.ResetColor();
            currentValue = SetCurrentValue(character, currentValue);

            if (character is not "") continue;
            Console.ResetColor();
            highestValue = SetHighestHistoricalValue(highestValue, currentValue);
            currentValue = 0;
        }

        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        return highestValue;
    }

    private static long SetCurrentValue(string s, long currentValue)
    {
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        if (s is "") return currentValue;
        Console.WriteLine($"Current value is {s}");
        var value = int.Parse(s);
        currentValue += value;
        Console.WriteLine($"Current sum of value is {currentValue}");

        return currentValue;
    }

    private static long SetHighestHistoricalValue(long highestValue, long currentValue)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine($"Time for a new line");
        if (highestValue < currentValue)
        {
            highestValue = currentValue;
            Console.WriteLine($"The new highest value is {highestValue}");
        }

        Console.WriteLine($"Resetting current value to 0 and the highest value is {highestValue}");
        return highestValue;
    }
}