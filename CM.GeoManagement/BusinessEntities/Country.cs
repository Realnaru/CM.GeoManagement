using CM.GeoManagement.Common;
using System;
using System.Collections.Generic;

namespace CM.GeoManagement
{
    public class Country
    {
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public List<Region> Regions { get; set; } = new List<Region>();

        public void AddRegion(Region region)
        {
            if (region.CountryCode != CountryCode)
            {
                throw new GeoException();
            }

            Regions.Add(region);
        }
    }

}
