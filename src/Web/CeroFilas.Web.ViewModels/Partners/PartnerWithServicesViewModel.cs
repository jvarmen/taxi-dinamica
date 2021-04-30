﻿namespace CeroFilas.Web.ViewModels.Partners
{
    using System.Collections.Generic;

    using CeroFilas.Data.Models;
    using CeroFilas.Services.Mapping;

    public class PartnerWithServicesViewModel : IMapFrom<Partner>
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public string CategoryName { get; set; }

        public string CityName { get; set; }

        public string Address { get; set; }

        public string Website { get; set; }

        public double Rating { get; set; }

        public int RatersCount { get; set; }

        public virtual ICollection<PartnerServiceViewModel> Services { get; set; }
    }
}