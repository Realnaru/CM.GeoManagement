using System;
using Xunit;
using CM.GeoManagement;
using CM.GeoManagement.Common;

namespace CM.GeoManagement.Tests
{
    public class CountryTests
    {
        [Fact]
        public void ShouldBeAbleToCreateCountry()
        {
            var country = new Country();
            country.CountryCode = "US";
            country.CountryName = "United States";

            Assert.Equal("US", country.CountryCode);
            Assert.Equal("United States", country.CountryName);



        }

        [Fact]
        public void ShouldBeAbleToAddRegionToCountry()
        {
            var country = new Country();
            country.CountryCode = "US";
            country.CountryName = "United States";

            var region = new Region();
            region.RegionCode = "IL";
            region.RegionName = "Illionois";
            region.CountryCode = "US";

            country.AddRegion(region);

            Assert.Equal(region, country.Regions[0]);
        }

        [Fact]
        public void ShouldBeAbleToAddRegionFromAnotherCountry()
        {
            var country = new Country();
            country.CountryCode = "US";
            country.CountryName = "United States";

            var region = new Region();
            region.CountryCode = "CA";

            Assert.Throws<GeoException>(() => country.AddRegion(region));
        }
    }

}
