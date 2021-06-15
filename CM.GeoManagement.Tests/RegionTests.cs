using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CM.GeoManagement.Tests
{
    public class RegionTests
    {
        [Fact]
        public void ShouldBeAbleToCreateRegion()
        {
            var region = new Region();
            region.RegionCode = "IL";
            region.CountryCode = "US";
            region.RegionName = "Illinois";

            Assert.Equal("IL", region.RegionCode);
            Assert.Equal("US", region.CountryCode);
            Assert.Equal("Illinois", region.RegionName);
        }

       
    }

}
