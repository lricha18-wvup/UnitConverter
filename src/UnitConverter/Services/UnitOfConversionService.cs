using UnitConverter.Models;
using UnitConverter.Pages;

namespace UnitConverter.Services;


public class UnitOfConversionService : IConversionService
{
    public decimal Convert(decimal value, string conversionType)
    {
        decimal result = 0;
        if (conversionType == ConversionTypes.MilesToKilometers)
        {
            result = (decimal)new UnitOf.Length()
                .FromMiles((double)value)
                .ToKilometers();
        } else if (conversionType == ConversionTypes.KilometersToMiles)
        {
            result = (decimal)new UnitOf.Length()
                .FromKilometers((double)value)
                .ToMiles();
        } else if (conversionType == ConversionTypes.FahrenheitToCelsius)
        {
            result = (decimal)new UnitOf.Temperature()
                .FromFahrenheit((double)value)
                .ToCelsius();
        }else if (conversionType == ConversionTypes.CelsiusToFahrenheit)
        {
            result = (decimal)new UnitOf.Temperature()
                .FromCelsius((double)value)
                .ToFahrenheit();
        }
        else if (conversionType == ConversionTypes.PoundsToKilograms)
        {
            result = (decimal)new UnitOf.Mass()
                .FromPounds((double)value)
                .ToKilograms();
        }else if (conversionType == ConversionTypes.KilogramsToPounds)
        {
            result = (decimal)new UnitOf.Mass()
                .FromKilograms((double)value)
                .ToPounds();

        } else if (conversionType == ConversionTypes.DaysToMinutes)
        {
            result = (decimal)new UnitOf.Time()
                .FromDays((double)value)
                .ToMinutes();

        }else if (conversionType == ConversionTypes.MinutesToDays)
        {
            result = (decimal)new UnitOf.Time()
                .FromMinutes((double)value)
                .ToDays();
        }

        return result;
    }


}
