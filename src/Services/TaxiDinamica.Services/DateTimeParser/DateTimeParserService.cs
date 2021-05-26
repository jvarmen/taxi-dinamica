namespace TaxiDinamica.Services.DateTimeParser
{
    using System;
    using System.Globalization;

    using TaxiDinamica.Common;

    public class DateTimeParserService : IDateTimeParserService
    {
        private const string Region = "es-ES";

        public DateTime ConvertStrings(string date, string time)
        {
            string dateString = date + " " + time;
            string format = GlobalConstants.DateTimeFormats.DateTimeFormat;
            CultureInfo provider = CultureInfo.InvariantCulture;
            // CultureInfo provider = new CultureInfo(Region);

            DateTime dateTime = DateTime.ParseExact(dateString, format, provider);

            return dateTime;
        }
    }
}
