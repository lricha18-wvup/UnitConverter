using System.Text.Json;
using UnitConverter.Models;

namespace UnitConverter.Services;

public class JsonLogReader : ILogReader
{
    private readonly string _logDirectory;

    public JsonLogReader(IWebHostEnvironment environment)
    {
        _logDirectory = Path.Combine(
            environment.ContentRootPath,
            "Logs");
    }

    public IEnumerable<LogEntry> Read()
    {
        List<LogEntry> entries = new List<LogEntry>();

        string[] logFiles;

        try
        {
            logFiles = Directory.GetFiles(_logDirectory, "*.json");
        }
        catch (DirectoryNotFoundException)
        {
            // Just checking to make sure log folder exists
            return entries;
        }

        foreach (string logFile in logFiles)
        {
            string[] lines;

            try
            {
                lines = File.ReadAllLines(logFile);
            }
            catch (IOException)
            {

                continue;
            }

            foreach (string line in lines)
            {
                LogEntry? entry;

                try
                {
                    entry = JsonSerializer.Deserialize<LogEntry>(line);
                }
                catch (JsonException)
                {
                    continue;
                }

                if (entry != null)
                {
                    if (string.IsNullOrEmpty(entry.Level))
                    {
                        entry.Level = "Information";
                    }

                    entries.Add(entry);
                }
            }
        }

        return entries;
    }
}
