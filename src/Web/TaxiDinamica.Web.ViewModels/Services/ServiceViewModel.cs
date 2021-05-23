namespace TaxiDinamica.Web.ViewModels.Services
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class ServiceViewModel : IMapFrom<Service>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public int PartnersCount { get; set; }

        public int AppointmentsCount { get; set; }
    }
}
