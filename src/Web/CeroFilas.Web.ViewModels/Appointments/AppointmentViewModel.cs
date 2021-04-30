namespace CeroFilas.Web.ViewModels.Appointments
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class AppointmentViewModel : IMapFrom<Appointment>
    {
        public string Id { get; set; }

        public DateTime DateTime { get; set; }

        public string UserEmail { get; set; }

        public string PartnerId { get; set; }

        public string PartnerName { get; set; }

        public string PartnerAddress { get; set; }

        public int ServiceId { get; set; }

        public string ServiceName { get; set; }

        public bool? Confirmed { get; set; }

        public bool? IsPartnerRatedByTheUser { get; set; }
    }
}
