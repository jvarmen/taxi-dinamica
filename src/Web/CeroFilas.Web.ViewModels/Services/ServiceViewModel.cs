namespace CeroFilas.Web.ViewModels.Services
{
    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

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
