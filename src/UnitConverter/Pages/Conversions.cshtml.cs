using Microsoft.AspNetCore.Mvc.RazorPages;

namespace UnitConverter.Pages;

public class ConversionsModel : PageModel
{
    public void OnGet()
    {
        Input = "3.1415";
        ViewData["ConversionType"] = "Miles to Kilometers";
        ViewData["Title"] = "Conversions";
        double milesValue = Convert.ToDouble(Input);
        double kilometersValue = new UnitOf.Length()
            .FromMiles(milesValue)
            .ToKilometers();
        Output = kilometersValue.ToString();

    }

    public string Input { get; set; } = string.Empty;

    public string Output { get; set; } = string.Empty;
}
