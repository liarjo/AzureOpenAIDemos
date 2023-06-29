using System;
using System.IO;
using Microsoft.DotNet.Interactive;
using System.Text.Json;




public static class TheHelper
{
    // Reads the contents of a text file and returns it as a string
    public static string ReadTextFile(string filePath)
    {
        try
        {
            string fileContents = File.ReadAllText(filePath, Encoding.UTF8);
            return fileContents;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading the file: {ex.Message}");
            return null;
        }
    }

    // Wraps long lines of text to fit within a specified character limit
    public static string ConsoleWriteLine(string input)
    {
        int breakInterval = 190;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < input.Length; i++)
        {
            sb.Append(input[i]);

            // Check if the current position is a multiple of breakInterval
            if ((i + 1) % breakInterval == 0)
            {
                sb.Append("\n");
            }
        }

        return sb.ToString();
    }

    // Gets a value from a JSON configuration file based on a specified key
    public static string GetConfigurationValue(string key)
    {
        try
        {
            string filePath = "../Config/settings.json";
            string json = File.ReadAllText(filePath);
            var documentOptions = new JsonDocumentOptions { AllowTrailingCommas = true };
            var document = JsonDocument.Parse(json, documentOptions);

            if (document.RootElement.TryGetProperty(key, out var value))
                return value.ToString();
            else
                throw new KeyNotFoundException($"Key '{key}' not found in the configuration file.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading configuration file: {ex.Message}");
            return null;
        }
    }
}