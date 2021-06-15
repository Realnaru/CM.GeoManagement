using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CM.GeoManagement.Tests
{
    public class CountryRepositoryTest
    {
        [Fact]
        public void ShouldBeAbleToCreateCountryRepository()
        {
            var countryRepository = new CountryRepository();

            Assert.NotNull(countryRepository);

        }

        [Fact]
        public void ShouldBeAbleToSaveCountry()
        {
            var countryRepository = new CountryRepository();

            countryRepository.DeletAll();

            var country = new Country();
            country.CountryCode = "US";
            country.CountryName = "United States";

            countryRepository.Add(country);

            var createdCountry = countryRepository.Get("US");
            Assert.NotNull(createdCountry);

            Assert.Equal(country.CountryCode, createdCountry.CountryCode);
            Assert.Equal(country.CountryName, createdCountry.CountryName);

        }

    }

}
