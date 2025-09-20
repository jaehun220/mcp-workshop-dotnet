using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyMonkeyApp.Models;

/// <summary>
/// Provides helper methods for managing monkey data.
/// </summary>
public static class MonkeyHelper
{
    private static List<Monkey> monkeys = new();
    private static int randomMonkeyAccessCount = 0;
    private static readonly HttpClient httpClient = new();
    private static bool isInitialized = false;

    /// <summary>
    /// Initializes the monkey data from the MCP server.
    /// </summary>
    public static async Task InitializeAsync()
    {
        if (isInitialized) return;
        // Replace with actual MCP server endpoint if available
        var url = "https://raw.githubusercontent.com/jamesmontemagno/app-monkeys/master/monkeydata.json";
        var response = await httpClient.GetStringAsync(url);
        var data = JsonSerializer.Deserialize<List<Monkey>>(response);
        if (data != null)
            monkeys = data;
        isInitialized = true;
    }

    /// <summary>
    /// Gets all monkeys.
    /// </summary>
    public static IEnumerable<Monkey> GetMonkeys()
    {
        return monkeys;
    }

    /// <summary>
    /// Gets a random monkey and tracks access count.
    /// </summary>
    public static Monkey? GetRandomMonkey()
    {
        if (!monkeys.Any()) return null;
        randomMonkeyAccessCount++;
        var rand = new Random();
        return monkeys[rand.Next(monkeys.Count)];
    }

    /// <summary>
    /// Finds a monkey by name (case-insensitive).
    /// </summary>
    public static Monkey? GetMonkeyByName(string name)
    {
        return monkeys.FirstOrDefault(m => m.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>
    /// Gets the number of times a random monkey has been picked.
    /// </summary>
    public static int GetRandomMonkeyAccessCount() => randomMonkeyAccessCount;
}
