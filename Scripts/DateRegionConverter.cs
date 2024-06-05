using UnityEngine;
using System.Globalization;
using System;

public static class DateRegionConverter
{
    private static readonly string americanDateFormat = "MM/dd/yyyy";
    private static readonly string brazilianDateFormat = "dd/MM/yyyy";

    /// <summary>
    /// Obt�m a data formatada de acordo com a regi�o do dispositivo.
    /// </summary>
    /// <param name="date">A data no formato a ser formatado.</param>
    /// <returns>A data formatada de acordo com a regi�o do dispositivo.</returns>
    public static string GetLocalizedDate(string date)
    {
        string region = GetDeviceRegion();
        return ConvertToLocalizedDateFormat(date, region);
    }

    private static string GetDeviceRegion()
    {
        string region = "";

#if UNITY_IOS
        if (CultureInfo.CurrentCulture != null)
            region = CultureInfo.CurrentCulture.DisplayName;
#elif UNITY_ANDROID
        AndroidJavaClass localeClass = new AndroidJavaClass("java.util.Locale");
        AndroidJavaObject defaultLocale = localeClass.CallStatic<AndroidJavaObject>("getDefault");
        region = defaultLocale.Call<string>("getCountry");
#else
        region = CultureInfo.CurrentCulture.Name;
#endif

        return region;
    }

    private static string ConvertToLocalizedDateFormat(string date, string region)
    {
        CultureInfo culture;
        string dateFormat;

        if (region.Equals("BR", System.StringComparison.OrdinalIgnoreCase))
        {
            culture = CultureInfo.CreateSpecificCulture("pt-BR");
            dateFormat = brazilianDateFormat;
        }
        else
        {
            culture = CultureInfo.InvariantCulture;
            dateFormat = americanDateFormat;
        }

        DateTime parsedDate = DateTime.ParseExact(date, americanDateFormat, CultureInfo.InvariantCulture);
        return parsedDate.ToString(dateFormat, culture);
    }
}
