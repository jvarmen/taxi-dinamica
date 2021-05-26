namespace TaxiDinamica.Web.ViewModels.Partners
{
    using TaxiDinamica.Data.Models;
    using TaxiDinamica.Services.Mapping;

    public class PartnerViewModel : IMapFrom<Partner>
    {
        public string Id { get; set; }
        public string Placa { get; set; }
        public string ImageUrl { get; set; }
        public string OwnerId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CityName { get; set; }
        public string DriverName { get; set; }
        public string DriverContact { get; set; }
        public double Rating { get; set; }
        public int RatersCount { get; set; }
        public int AppointmentsCount { get; set; }
    }
}
