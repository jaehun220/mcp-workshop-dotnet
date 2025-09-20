using System;
using System.Threading.Tasks;
using MyMonkeyApp.Models;

namespace MyMonkeyApp;

/// <summary>
/// Entry point for the Monkey Console Application.
/// </summary>
public class Program
{
    private static readonly string[] AsciiArts = new[]
    {
        @"  (o\_/o)",
        @" (='.'=)",
        @" (")_(")",
        @"  (o.o)",
        @"  ( : )",
        @"  (\__/)",
        @"  (='.'=)",
        @"  (")_(")"
    };

    public static async Task Main(string[] args)
    {
        await MonkeyHelper.InitializeAsync();
        var running = true;
        var rand = new Random();
        while (running)
        {
            Console.Clear();
            // Display random ASCII art
            Console.WriteLine(AsciiArts[rand.Next(AsciiArts.Length)]);
            Console.WriteLine("============================");
            Console.WriteLine("Monkey Console Application");
            Console.WriteLine("============================");
            Console.WriteLine("1. List all monkeys");
            Console.WriteLine("2. Get details for a specific monkey by name");
            Console.WriteLine("3. Get a random monkey");
            Console.WriteLine("4. Exit app");
            Console.Write("Select an option: ");
            var input = Console.ReadLine();
            Console.WriteLine();
            switch (input)
            {
                case "1":
                    ListAllMonkeys();
                    break;
                case "2":
                    GetMonkeyByName();
                    break;
                case "3":
                    GetRandomMonkey();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
            if (running)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }

    private static void ListAllMonkeys()
    {
        Console.WriteLine("\nAvailable Monkeys:");
        Console.WriteLine("------------------");
        foreach (var monkey in MonkeyHelper.GetMonkeys())
        {
            Console.WriteLine($"- {monkey.Name} ({monkey.Location})");
        }
    }

    private static void GetMonkeyByName()
    {
        Console.Write("Enter monkey name: ");
        var name = Console.ReadLine() ?? string.Empty;
        var monkey = MonkeyHelper.GetMonkeyByName(name);
        if (monkey != null)
        {
            Console.WriteLine($"\nName: {monkey.Name}");
            Console.WriteLine($"Location: {monkey.Location}");
            Console.WriteLine($"Population: {monkey.Population}");
            Console.WriteLine($"Details: {monkey.Details}");
            Console.WriteLine($"Image: {monkey.Image}");
        }
        else
        {
            Console.WriteLine("Monkey not found.");
        }
    }

    private static void GetRandomMonkey()
    {
        var monkey = MonkeyHelper.GetRandomMonkey();
        if (monkey != null)
        {
            Console.WriteLine($"\nRandom Monkey:");
            Console.WriteLine($"Name: {monkey.Name}");
            Console.WriteLine($"Location: {monkey.Location}");
            Console.WriteLine($"Population: {monkey.Population}");
            Console.WriteLine($"Details: {monkey.Details}");
            Console.WriteLine($"Image: {monkey.Image}");
            Console.WriteLine($"Random monkey picked {MonkeyHelper.GetRandomMonkeyAccessCount()} times.");
        }
        else
        {
            Console.WriteLine("No monkeys available.");
        }
    }
}
