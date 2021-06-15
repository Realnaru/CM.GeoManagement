using System;
using Xunit;

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
    }
}
