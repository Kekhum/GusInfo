using Xunit;

namespace GusInfo.Tests
{
    public class GusClientTest
    {
        [Fact]
        public void gusclient_shoud_return_gusinfo()
        {
            var gusInfo = new GusCompanyInfo
            {
                Name = "GŁÓWNY URZĄD STATYSTYCZNY",
                Nip = "5261040828",
                Regon = "00033150100000",
                City = "Warszawa",
                ZipCode = "00-925",
                Street = "ul. Test-Krucza"
            };

            var sut = new GusClient();
            var result = sut.GetCompanyByNip(gusInfo.Nip);

            Assert.NotNull(result);
            Assert.Equal("GŁÓWNY URZĄD STATYSTYCZNY", result.Name);
            Assert.Equal("00033150100000", result.Regon);
        }

    }
}
