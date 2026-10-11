using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Pages;

public class LogsModel : PageModel
{
    private readonly ILogReader _logReader;

    public LogsModel(ILogReader logReader)
    {
        _logReader = logReader;
    }

    public List<LogEntry> Entries { get; set; } = new List<LogEntry>();

    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? Level { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? ConversionType { get; set; }

    public void OnGet()
    {
        foreach (LogEntry entry in _logReader.Read())
        {
            if (!string.IsNullOrEmpty(Level) && entry.Level != Level)
            {
                continue;
            }

            if (!string.IsNullOrEmpty(ConversionType) && entry.ConversionType != ConversionType)
            {
                continue;
            }

            if (!string.IsNullOrEmpty(Search))
            {
                string text = $"{entry.Message} {entry.Exception} {entry.ConversionType} {entry.Input} {entry.Result}";

                if (!text.Contains(Search, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
            }

            Entries.Add(entry);
        }
    }
}
