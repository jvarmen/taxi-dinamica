namespace TaxiDinamica.Common
{
    public static class GlobalConstants
    {

        public const string AdministratorRoleName = "Administrador";

        public const string CloudName = "cero-filas";

        public const string PartnerManagerRoleName = "Representante Legal";
        public const string SystemName = "Taxi Dinámica";

        public static class AccountsSeeding
        {

            public const string AdminEmail = "admin@admin.com";

            public const string PartnerManagerEmail = "manager@manager.com";
            public const string Password = "admin12345";

            public const string UserEmail = "user@user.com";
        }

        public static class DataValidations
        {

            public const int AddressMaxLength = 100;

            public const int AddressMinLength = 5;

            public const int ContentMaxLength = 3500;

            public const int ContentMinLength = 700;

            public const int DescriptionMaxLength = 700;

            public const int DescriptionMinLength = 50;

            public const int NameMaxLength = 40;

            public const int NameMinLength = 2;
            public const int TitleMaxLength = 60;

            public const int TitleMinLength = 5;
        }

        public static class DateTimeFormats
        {
            public const string DateFormat = "dd-MM-yyyy";

            public const string DateTimeFormat = "dd-MM-yyyy h:mmtt";

            public const string TimeFormat = "h:mmtt";
        }

        public static class ErrorMessages
        {

            public const string Address = "Address must be between 5 and 100 characters.";

            public const string Author = "Author name must be between 2 and 40 characters.";

            public const string Content = "Content must be between 700 and 3500 characters.";

            public const string DateTime = "Please select a valid DATE and TIME from the datepicker calendar on the left.";

            public const string Description = "Description must be between 50 and 700 characters.";

            public const string Image = "Please select a JPG, JPEG or PNG image smaller than 1MB.";

            public const string Name = "Name must be between 2 and 40 characters.";

            public const string Rating = "Please choose a valid number of stars from 1 to 5.";
            public const string Title = "Title must be between 5 and 60 characters.";
        }

        public static class Images
        {
            public const string DemoImg = "https://res.cloudinary.com/cero-filas/image/upload/v1619833036/open-center_hl245i.jpg";
        }

        public static class SeededDataCounts
        {

            public const int Appointments = 54;

            public const int Categories = 6;

            public const int Cities = 2;

            public const int Partners = 18;

            public const int Services = 55;
        }
    }
}
