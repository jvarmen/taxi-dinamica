namespace TaxiDinamica.Services.DateTimeParser
{
    using System;
    using System.Globalization;

    using TaxiDinamica.Common;

    public class DateTimeParserService : IDateTimeParserService
    {
        public DateTime ConvertStrings(string date, string time)
        {
            string dateString = date + " " + time;
            string format = GlobalConstants.DateTimeFormats.DateTimeFormat;
            // CultureInfo provider = new CultureInfo("es-CO");
            CultureInfo provider = CultureInfo.InvariantCulture;

            DateTime dateTime = DateTime.ParseExact(dateString, format, provider);

            return dateTime;
        }
    }
}
