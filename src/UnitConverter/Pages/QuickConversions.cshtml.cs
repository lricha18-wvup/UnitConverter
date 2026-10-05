using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UnitConverter.Models;
using UnitConverter.Services;

namespace UnitConverter.Pages;

public class QuickConversions : PageModel
{
    private readonly IConversionService _UnitOfConversionService;
    public decimal? Output { get; set; }


    public QuickConversions(IConversionService UnitOfConversionService)
    {
        _UnitOfConversionService = UnitOfConversionService;
    }
    public void OnGet()
    {

    }


    public IEnumerable<SelectListItem> PoundOptions =>
    [
        new("1 pound", "1"),
        new("5 pounds", "5"),
        new("10 pounds", "10"),
        new("25 pounds", "25"),
        new("50 pounds", "50")
    ];


    [ViewData]
    public string? ErrorMessage { get; set; }

    public IActionResult OnGetMilesToKilometers(String input)
    {

        return PerformConversion(input, ConversionTypes.MilesToKilometers);
    }

    public IActionResult OnGetKilometersToMiles(string input)
    {
        return PerformConversion(input, ConversionTypes.KilometersToMiles);
    }

    public IActionResult OnGetFahrenheitToCelsius(string input)
    {
        return PerformConversion(input, ConversionTypes.FahrenheitToCelsius);
    }

    public IActionResult OnGetCelsiusToFahrenheit(string input)
    {
        return PerformConversion(input, ConversionTypes.CelsiusToFahrenheit);
    }

    public IActionResult OnGetPoundsToKilograms(string input)
    {
        return PerformConversion(input, ConversionTypes.PoundsToKilograms);
    }

    public IActionResult OnGetKilogramsToPounds(string input)
    {
        return PerformConversion(input, ConversionTypes.KilogramsToPounds);
    }

    public IActionResult OnGetDaysToMinutes(string input)
    {
        return PerformConversion(input, ConversionTypes.DaysToMinutes);
    }

    public IActionResult OnGetMinutesToDays(string input)
    {
        return PerformConversion(input, ConversionTypes.MinutesToDays);
    }

    private IActionResult PerformConversion(string input, string type)
    {
        if (!decimal.TryParse(input, out var value))
        {
            ErrorMessage = "Please enter a valid number.";
            return Page();

        }

        Output = _UnitOfConversionService.Convert(value, type);
        return Page();
    }




    }



